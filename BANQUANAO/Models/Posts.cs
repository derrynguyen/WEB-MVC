using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANQUANAO.Models
{
    public class Posts
    {

        [Key]
        public int IDPosts { get; set; }

        public string contentPots { get; set; }
        public string ImgPosts { get; set; }
        public int likePots { get; set; }   
        public DateTime timePosts { get; set; }

        public int ID { get; set; }


        public virtual Users Users { get; set; }

    }
}