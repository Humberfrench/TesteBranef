﻿using Dietcode.Core.DomainValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Branef.ViewModel.Interfaces
{
    public interface IBaseApp
    {
        void BeginTransaction();
        Task Commit();
    }
}
