﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation
{
    public interface IImageSerializer
    {
        string Serialize(Image i);
        Image Parse(String imageData);
    }
}
