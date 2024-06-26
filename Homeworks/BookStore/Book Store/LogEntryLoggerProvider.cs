﻿using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;

namespace Book_Store
{
    public class LogEntryLoggerProvider : ILoggerProvider
    {
        public static ObservableCollection<LogEntry> LogEntites { get; } = new();

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName);
        }

        public void Dispose()
        {
        }

        public class Logger : ILogger
        {
            private readonly string _categoryName;

            public Logger(string categoryName)
            {
                _categoryName = categoryName;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
                if (logLevel == LogLevel.Critical || logLevel == LogLevel.Error || logLevel == LogLevel.Warning ||
                    logLevel == LogLevel.Information)
                    RecordMsg(logLevel, eventId, state, exception, formatter);
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return new NoopDisposable();
            }

            private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
                LogEntites.Add(new LogEntry
                {
                    Timestamp = DateTime.Now.ToString(),
                    Level = logLevel.ToString(),
                    Message = formatter(state, exception)
                });
            }

            private class NoopDisposable : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }

        public class LogEntry
        {
            public string Timestamp { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }
        }
    }
}