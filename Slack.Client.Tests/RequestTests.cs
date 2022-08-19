using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Slack.Client.Dtos.BaseTypes;

namespace Slack.Client.Tests;

public class RequestTests
{
    [Fact]
    public void PostMessage_Throws_AttachmentsBlocksOrTextIsNotPresent()
    {
        var action = () => new PostMessage("", blocks: null, text: null);
        action.Should().Throw<ArgumentException>($"Either blocks or text must be present.");
    }

    public static IEnumerable<object[]> PostMessage_Valid_Data()
    {
        return new List<object[]> {
            new object[] { new List<Section>(), "" },
            new object[] { new List<Section>() { new Dtos.ImageSection("","") }, "" },
        };
    }

    [Theory]
    [MemberData(nameof(PostMessage_Valid_Data))]
    public void PostMessage_Valid(List<Section>? blockInput, string? textInput)
    {
        var message = new PostMessage("", blocks: blockInput, text: textInput);
        message.Text.Should().Be(textInput);
        message.Blocks?.Count().Should().Be(blockInput?.Count());
        for (int i = 0; i < message.Blocks?.Count(); i++)
        {
            message.Blocks.ElementAt(i)?.Should().Be(blockInput[i]);
        }
    }
}
