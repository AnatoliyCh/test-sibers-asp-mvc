﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2_PresentationLayer.Startup))]
namespace _2_PresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
