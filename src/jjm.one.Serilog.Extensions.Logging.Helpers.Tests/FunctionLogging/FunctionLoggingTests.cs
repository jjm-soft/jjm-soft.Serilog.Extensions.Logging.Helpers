using System;
using jjm.one.Microsoft.Extensions.Logging.Helpers.Tests.util;
using Microsoft.Extensions.Logging;
using Moq;

namespace jjm.one.Microsoft.Extensions.Logging.Helpers.Tests.FunctionLogging;

public class FunctionLoggingTests
{
    #region private members
    
    private readonly Mock<ILogger> _logger;

    private readonly DummyClass _sut; 
    
    #endregion

    #region ctors

    public FunctionLoggingTests()
    {
        _logger = new Mock<ILogger>();

        _sut = new DummyClass(_logger.Object);
    }

    #endregion

    #region tests

    [Fact]
    public void LogFctCallTest1()
    {
        // arrange
        _logger.Setup(x => x.Log(LogLevel.Debug, 0, It.IsAny<object>(), 
            It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()!)).Verifiable();

        // act 
        _sut.Test1();

        // assert
        _logger.Verify(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Debug),
                0,
                It.Is<It.IsAnyType>((@o, @t) => 
                        @o.ToString()!.Equals($"Function called: {nameof(DummyClass)} -> {nameof(_sut.Test1)}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest2()
    {
        // arrange
        _logger.Setup(x => x.Log(LogLevel.Debug, 0, It.IsAny<object>(), 
            It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()!)).Verifiable();

        // act 
        _sut.Test2();

        // assert
        _logger.Verify(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Debug),
                0,
                It.Is<It.IsAnyType>((@o, @t) => 
                    @o.ToString()!.Equals($"Function called: {nameof(DummyClass)} -> {nameof(_sut.Test2)}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest3()
    {
        // arrange
        _logger.Setup(x => x.Log(LogLevel.Error, 0, It.IsAny<object>(), 
            It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()!)).Verifiable();

        // act 
        _sut.Test3();

        // assert
        _logger.Verify(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                0,
                It.Is<It.IsAnyType>((@o, @t) => 
                    @o.ToString()!.Equals($"Exception thrown in: {nameof(DummyClass)} -> {nameof(_sut.Test3)}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest4()
    {
        // arrange
        _logger.Setup(x => x.Log(LogLevel.Error, 0, It.IsAny<object>(), 
            It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()!)).Verifiable();

        // act 
        _sut.Test4();

        // assert
        _logger.Verify(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                0,
                It.Is<It.IsAnyType>((@o, @t) => 
                    @o.ToString()!.Equals($"Exception thrown in: {nameof(DummyClass)} -> {nameof(_sut.Test4)}\nTestMSG")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest5()
    {
        // arrange
        _logger.Setup(x => x.Log(LogLevel.Error, 0, It.IsAny<object>(), 
            It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()!)).Verifiable();

        // act 
        _sut.Test5();

        // assert
        _logger.Verify(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                0,
                It.Is<It.IsAnyType>((@o, @t) => 
                    @o.ToString()!.Equals($"Exception thrown in: {nameof(DummyClass)} -> {nameof(_sut.Test5)}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest6()
    {
        // arrange
        _logger.Setup(x => x.Log(LogLevel.Error, 0, It.IsAny<object>(), 
            It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()!)).Verifiable();

        // act 
        _sut.Test6();

        // assert
        _logger.Verify(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                0,
                It.Is<It.IsAnyType>((@o, @t) => 
                    @o.ToString()!.Equals($"Exception thrown in: {nameof(DummyClass)} -> {nameof(_sut.Test6)}\nTestMSG")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once);
    }

    #endregion
}