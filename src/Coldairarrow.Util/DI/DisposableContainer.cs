﻿using System;
using System.Collections.Generic;

namespace Coldairarrow.Util
{
    public class DisposableContainer : IDisposableContainer, IDisposable
    {
        SynchronizedCollection<IDisposable> _objList
            = new SynchronizedCollection<IDisposable>();

        public void AddDisposableObj(IDisposable disposableObj)
        {
            if (!_objList.Contains(disposableObj))
                _objList.Add(disposableObj);
        }

        public void Dispose()
        {
            _objList.ForEach(x =>
            {
                try
                {
                    AutofacHelper.GetService<ILogger>().Warn(LogType.系统测试, "释放");
                    x.Dispose();
                }
                catch
                {

                }
            });
            _objList.Clear();
        }
    }
}

