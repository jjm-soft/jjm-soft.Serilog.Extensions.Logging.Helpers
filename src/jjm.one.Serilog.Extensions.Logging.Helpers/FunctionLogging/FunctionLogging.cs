﻿using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Reflection;

namespace jjm.one.Serilog.Extensions.Logging.Helpers
{
    /// <summary>
    /// Static class for all function logging helper extensions.
    /// </summary>
    public static class FunctionLogging
    {

        /// <summary>
        /// Log a function/method call.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="level">The logging level. Default is <see cref="LogEventLevel.Debug"/>.</param>
        public static void LogFctCall(this ILogger logger, LogEventLevel level = LogEventLevel.Debug)
        {
            var method = new StackTrace().GetFrame(1)?.GetMethod();

            logger.Write(level, "Function called: {ClassName} -> {FctName}",
                method?.DeclaringType?.Name, method?.Name);
        }
        
        /// <summary>
        /// Log a function/method call.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="classType">The <see cref="Type"/> of the calling class.</param>
        /// <param name="methodType">The <see cref="MethodBase"/> of the calling function/method.</param>
        /// <param name="level">The logging level. Default is <see cref="LogEventLevel.Debug"/>.</param>
        public static void LogFctCall(this ILogger logger, Type? classType, MethodBase? methodType, 
            LogEventLevel level = LogEventLevel.Debug)
        {
            logger.Write(level, "Function called: {ClassName} -> {FctName}", 
                classType?.Name, methodType?.Name);
        }

        /// <summary>
        /// Log an exception within a function/method call.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="exc">The exception.</param>
        /// <param name="msg">The message of the exception.</param>
        /// <param name="level">The logging level. Default is <see cref="LogEventLevel.Error"/>.</param>
        public static void LogExcInFctCall(this ILogger logger, Exception exc, string? msg = null, 
            LogEventLevel level = LogEventLevel.Error)
        {
            var method = new StackTrace().GetFrame(1)?.GetMethod();
            
            if (string.IsNullOrEmpty(msg))
            {
                logger.Write(level, exc, "Exception thrown in: {ClassName} -> {FctName}",
                    method?.DeclaringType?.Name, method?.Name);
            }
            else
            {
                logger.Write(level, exc, "Exception thrown in: {ClassName} -> {FctName}\n" + msg,
                    method?.DeclaringType?.Name, method?.Name);
            }
        }
        
        /// <summary>
        /// Log an exception within a function/method call.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="exc">The exception.</param>
        /// <param name="classType">The <see cref="Type"/> of the calling class.</param>
        /// <param name="methodType">The <see cref="MethodBase"/> of the calling function/method.</param>
        /// <param name="msg">The message of the exception.</param>
        /// <param name="level">The logging level. Default is <see cref="LogEventLevel.Error"/>.</param>
        public static void LogExcInFctCall(this ILogger logger, Exception exc, Type? classType,
            MethodBase? methodType, string? msg = null, LogEventLevel level = LogEventLevel.Error)
        {
            if (string.IsNullOrEmpty(msg))
            {
                logger.Write(level, exc, "Exception thrown in: {ClassName} -> {FctName}", 
                    classType?.Name, methodType?.Name);
            }
            else
            {
                logger.Write(level, exc, "Exception thrown in: {ClassName} -> {FctName}\n" + msg, 
                    classType?.Name, methodType?.Name);
            }
        }
    }
}
