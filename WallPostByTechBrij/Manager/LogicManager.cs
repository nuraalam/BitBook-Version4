using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WallPostByTechBrij.Models;
using WebGrease.Css.Extensions;

namespace WallPostByTechBrij.Manager
{
    public class LogicManager
    {
        WallEntities db=new WallEntities();
        public bool CheckLike(Like like)
        {
            return db.Likes.ToList().Where(aLike => aLike.PostId == like.PostId).All(aLike => aLike.LikeBy != like.LikeBy);
        }

        public void IncreaseLike(Like like)
        {
            var aPost = db.Posts.Find(like.PostId);
            aPost.LikeCount++;
            db.Posts.AddOrUpdate(aPost);
            db.SaveChanges();
        }

        public void DecreaseLike(Like like)
        {
            var aPost = db.Posts.Find(like.PostId);
            aPost.LikeCount--;
            db.Posts.AddOrUpdate(aPost);
            db.SaveChanges();
            foreach (var aLike in db.Likes.ToList())
            {
                if (aLike.PostId==like.PostId)
                {
                    if (aLike.LikeBy == like.LikeBy)
                    {
                        db.Likes.Remove(aLike);
                        db.SaveChanges();
                    }
                    
                }
            }
        

        }
    }
}