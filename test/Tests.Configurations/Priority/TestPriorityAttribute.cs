namespace Tests.Configurations.Priority;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TestPriorityAttribute(int priority) : Attribute
{
    public int Priority { get; private set; } = priority;
}

// Source: https://github.com/xunit/samples.xunit/blob/main/TestOrderExamples/TestCaseOrdering/TestPriorityAttribute.cs