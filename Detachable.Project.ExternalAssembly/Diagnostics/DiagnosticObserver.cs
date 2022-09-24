﻿using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Detachable.Project.ExternalAssembly.Diagnostics
{
    internal class DiagnosticObserver : IObserver<DiagnosticListener>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly int _minCommandElapsedMilliseconds;
        public DiagnosticObserver(
            ILoggerFactory loggerFactory,
            int minCommandElapsedMilliseconds
            )
        {
            _loggerFactory = loggerFactory;
            _minCommandElapsedMilliseconds = minCommandElapsedMilliseconds;
        }
        public void OnCompleted()
            => throw new NotImplementedException();

        public void OnError(Exception error)
            => throw new NotImplementedException();

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name == "") // 自定义日志
            {
                value.Subscribe(new KeyValueObserver(_loggerFactory, _minCommandElapsedMilliseconds));
            }
        }
    }
}
