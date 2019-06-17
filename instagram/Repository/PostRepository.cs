using instagram.Models;
using instagram.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.Repository
{
    public class PostRepository
    {

        private DbContext dbContext;
        public PostRepository()
        {
            dbContext = new DbContext();

        }

        public IEnumerable<Post> GetList()
        {

            return dbContext.Posts.AsQueryable().ToList();
        }

        public void Created(Post post)
        {
            dbContext.Posts.InsertOne(post);
        }


    }
}
