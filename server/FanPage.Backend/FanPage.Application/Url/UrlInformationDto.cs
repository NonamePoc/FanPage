using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Url
{
    public class UrlInformationDto
    {
        public string BaseAddress { get; }

        public string ControllerRoute { get; }

        public string MethodRoute { get; }

        public UrlInformationDto(string baseAddress, string controllerRoute, string methodRoute)
        {
            BaseAddress = baseAddress;
            ControllerRoute = controllerRoute;
            MethodRoute = methodRoute;
        }

        public UrlInformationDto(string baseAddress, string controllerRoute)
        {
            BaseAddress = baseAddress;
            ControllerRoute = controllerRoute;
        }
    }
}