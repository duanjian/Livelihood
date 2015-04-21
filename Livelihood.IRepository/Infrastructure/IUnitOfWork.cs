﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livelihood.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// 提交数据
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
