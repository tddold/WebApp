﻿using App.Data.Common.Models;
using App.Data.Models;

namespace App.Services.Data.Common.Contracts
{
    public interface IGalleryService : IBaseDataService<Gallery>, IDeletableEntity
    {
    }
}