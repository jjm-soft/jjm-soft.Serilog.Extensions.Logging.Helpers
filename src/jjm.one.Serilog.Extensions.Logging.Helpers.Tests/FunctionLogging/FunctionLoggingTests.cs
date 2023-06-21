using System;
using jjm.one.Serilog.Extensions.Logging.Helpers.Tests.util;
using Moq;
using Serilog.Events;
using Serilog;

namespace jjm.one.Serilog.Extensions.Logging.Helpers.Tests.FunctionLogging;

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
        _logger.Setup(x => x.Write(LogEventLevel.Debug, 
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _sut.Test1();
        
        // assert
        _logger.Verify(logger => logger.Write(LogEventLevel.Debug,
                "Function called: {ClassName} -> {FctName}", 
                nameof(DummyClass), nameof(DummyClass.Test1)),
                Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest2()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, 
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _sut.Test2();

        // assert
        _logger.Verify(logger => logger.Write(LogEventLevel.Debug,
                "Function called: {ClassName} -> {FctName}", 
                nameof(DummyClass), nameof(DummyClass.Test2)),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest3()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _sut.Test3();

        // assert
        _logger.Verify(logger => logger.Write(LogEventLevel.Error,
                It.IsAny<Exception>(),
                "Exception thrown in: {ClassName} -> {FctName}", 
                nameof(DummyClass), nameof(DummyClass.Test3)),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest4()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _sut.Test4();

        // assert
        _logger.Verify(logger => logger.Write(LogEventLevel.Error,
                It.IsAny<Exception>(),
                "Exception thrown in: {ClassName} -> {FctName}\nTestMSG", 
                nameof(DummyClass), nameof(DummyClass.Test4)),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest5()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _sut.Test5();

        // assert
        _logger.Verify(logger => logger.Write(LogEventLevel.Error,
                It.IsAny<Exception>(),
                "Exception thrown in: {ClassName} -> {FctName}", 
                nameof(DummyClass), nameof(DummyClass.Test5)),
            Times.Once);
    }
    
    [Fact]
    public void LogFctCallTest6()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _sut.Test6();

        // assert
        _logger.Verify(logger => logger.Write(LogEventLevel.Error,
                It.IsAny<Exception>(),
                "Exception thrown in: {ClassName} -> {FctName}\nTestMSG", 
                nameof(DummyClass), nameof(DummyClass.Test6)),
            Times.Once);
    }

    #endregion
}