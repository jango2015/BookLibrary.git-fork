using System;
using System.Linq;
using FluentAssertions;
using ServiceStack.Redis;
using ServiceStack.Text;
using Xunit;

namespace Redis.Practice.Tests
{
    public class PostBlogTests:IClassFixture<TestFixture>
    {
        private readonly RedisClient _redis;

        public PostBlogTests(TestFixture testFixture)
        {
            _redis = testFixture.Redis;
        }

        [Fact]
        public void Show_a_list_of_blogs()
        {
            var redisBlogs = _redis.As<Blog>();
            var blogs = redisBlogs.GetAll();

            blogs.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Show_a_list_of_recent_posts_and_comments()
        {
            //Get strongly-typed clients
            var redisBlogPosts = _redis.As<BlogPost>();
            var redisComments = _redis.As<BlogPostComment>();
            {
                //To keep this example let's pretend this is a new list of blog posts
                var newIncomingBlogPosts = redisBlogPosts.GetAll();

                //Let's get back an IList<BlogPost> wrapper around a Redis server-side List.
                var recentPosts = redisBlogPosts.Lists["urn:BlogPost:RecentPosts"];
                var recentComments = redisComments.Lists["urn:BlogPostComment:RecentComments"];
                foreach (var newBlogPost in newIncomingBlogPosts)
                {
                    //Prepend the new blog posts to the start of the 'RecentPosts' list
                    recentPosts.Prepend(newBlogPost);

                    //Prepend all the new blog post comments to the start of the 'RecentComments' list
                    newBlogPost.Comments.ForEach(recentComments.Prepend);
                }

                //Make this a Rolling list by only keep the latest 3 posts and comments
                recentPosts.Trim(0, 2);
                recentComments.Trim(0, 2);

                recentPosts.PrintDump();
                recentComments.PrintDump();
            }

        }

        [Fact]
        public void Show_a_TagCloud()
        {
            //Get strongly-typed clients
            var redisBlogPosts = _redis.As<BlogPost>();
            var newIncomingBlogPosts = redisBlogPosts.GetAll();

            foreach (var newBlogPost in newIncomingBlogPosts)
            {
                //For every tag in each new blog post, increment the number of times each Tag has occurred 
                newBlogPost.Tags.ForEach(x =>
                    _redis.IncrementItemInSortedSet("urn:TagCloud", x, 1));
            }

            var tagCloud = _redis.GetRangeWithScoresFromSortedSetDesc("urn:TagCloud", 0, 4);
            tagCloud.PrintDump();
        }

        [Fact]
        public void Show_all_Categories()
        {
            var redisBlogPosts = _redis.As<BlogPost>();
            var blogPosts = redisBlogPosts.GetAll();

            foreach (var blogPost in blogPosts)
            {
                blogPost.Categories.ForEach(x =>
                        _redis.AddItemToSet("urn:Categories", x));
            }

            var uniqueCategories = _redis.GetAllItemsFromSet("urn:Categories");
            uniqueCategories.PrintDump();
        }

        [Fact]
        public void Show_post_and_all_comments()
        {
            //There is nothing special required here as since comments are Key Value Objects 
            //they are stored and retrieved with the post
            var postId = 1;
            var redisBlogPosts = _redis.As<BlogPost>();
            var selectedBlogPost = redisBlogPosts.GetById(postId.ToString());
            selectedBlogPost.PrintDump();
        }

        [Fact]
        public void Add_comment_to_existing_post()
        {
            var postId = 1;
            var redisBlogPosts = _redis.As<BlogPost>();
            var blogPost = redisBlogPosts.GetById(postId.ToString());
            blogPost.Comments.Add(
                new BlogPostComment { Content = "Third Post!", CreatedDate = DateTime.UtcNow });
            redisBlogPosts.Store(blogPost);

            var refreshBlogPost = redisBlogPosts.GetById(postId.ToString());
            refreshBlogPost.PrintDump();
        }

        [Fact]
        public void Show_all_Posts_for_the_DocumentDB_Category()
        {
            var redisBlogPosts = _redis.As<BlogPost>();
            var newIncomingBlogPosts = redisBlogPosts.GetAll();

            foreach (var newBlogPost in newIncomingBlogPosts)
            {
                //For each post add it's Id into each of it's 'Cateogry > Posts' index
                newBlogPost.Categories.ForEach(x =>
                        _redis.AddItemToSet("urn:Category:" + x, newBlogPost.Id.ToString()));
            }

            //Retrieve all the post ids for the category you want to view
            var documentDbPostIds = _redis.GetAllItemsFromSet("urn:Category:DocumentDB");

            //Make a batch call to retrieve all the posts containing the matching ids 
            //(i.e. the DocumentDB Category posts)
            var documentDbPosts = redisBlogPosts.GetByIds(documentDbPostIds);

            documentDbPosts.PrintDump();
        }
    }
}