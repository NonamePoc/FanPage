﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Photo
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        public string UserId { get; set; }
    }
}