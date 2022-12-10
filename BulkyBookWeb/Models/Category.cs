using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key] // this tells the sql to make the Id as the primary key and identity column in Database
        public int Id { get; set; }  //Property 
        [Required]// this tells the sql that name is required property and it should not be null.
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(10,1000,ErrorMessage ="Display order should between 10 to 1000 only")]
        public int DisplaySeq { get; set; }
        public DateTime Createddatetime { get; set; } = DateTime.Now;

    }
}
