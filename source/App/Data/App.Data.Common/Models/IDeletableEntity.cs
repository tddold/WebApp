﻿using System;

namespace App.Data.Common.Models
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        //DateTime DeletedOn { get; set; }
    }
}
