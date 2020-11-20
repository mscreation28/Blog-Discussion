using AutoMapper;
using BlogDiscussion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.ViewModels
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Blog, BlogViewModel>();
        }
    }
}
