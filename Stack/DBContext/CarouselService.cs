using Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stack.DBContext
{
    public static class CarouselService
    {
        public static List<Carousel> CarouselList = new List<Carousel>()
        {
            new Carousel()
            {
                Id=1,
                Description="ISO Certified. High Quality",
                ImgSrc="slide1.jpg",
                Title="Stack Lamb"
            },
            new Carousel()
            {
                Id=2,
                Description="Our Values is High Quality, and Technology Made In Egypt",
                ImgSrc="slide2.jpg",
                Title="Technology and Quality"
            },
             new Carousel()
            {
                Id=3,
                Description="Strongest led lamb in Egypt",
                ImgSrc="slide3.jpg",
                Title="Enjoy Day light"
            }
        };
    }
}