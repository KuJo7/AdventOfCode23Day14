namespace TestProject1;

using System.Diagnostics;
using FluentAssertions;
using Testit;

public class Day14Tests
{
    [Fact]
    public void Part1_TestData()
    {
        Day14.Part1(@"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....").Should().Be(136);
    }

    [Fact]
    public void Part2_TestData()
    {
        Day14.Part2(@"
O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....").Should().Be(136);
    }

    [Fact]
    public void CreateBlock_WithOneChar()
    {
        var blocksRound = Day14.CreateBlock("O");
        var blocksNone = Day14.CreateBlock(".");
        var blocksCube = Day14.CreateBlock("#");

        blocksRound.Should().BeEquivalentTo(new Block[1, 1] { {Block.Round} });
        blocksNone.Should().BeEquivalentTo(new Block[1, 1] { {Block.None} });
        blocksCube.Should().BeEquivalentTo(new Block[1, 1] { {Block.Cube} });
    }

    [Fact]
    public void CreateBlock_WithTwoChars_Horizontal()
    {
        var blocks = Day14.CreateBlock("O.");

        blocks.Should().BeEquivalentTo(new Block[2, 1] { {Block.Round}, {Block.None }});
    }

    [Fact]
    public void CreateBlock_WithTwoChars_Vertical()
    {
        var blocks = Day14.CreateBlock("O\r\n.");

        blocks.Should().BeEquivalentTo(new Block[1, 2] { {Block.Round, Block.None }});
    }

    [Fact]
    public void CreateBlock_ToString()
    {
        var blocks = Day14.CreateBlock(
            """
            O.#
            .O.
            O.O
            """);

        var sBlocks = Blocks.ToString(blocks);

        sBlocks.Should().Be(
            """
            O.#
            .O.
            O.O
            """);
    }

    [Fact]
    public void MoveNorth_TestData()
    {
        var blocks = Day14.CreateBlock(
            """
            O.#
            .O.
            O.O
            """);

        var width = blocks.GetLength(0);
        var height = blocks.GetLength(1);
        Day14.MoveNorth(width, height, blocks);

        var sBlocks = Blocks.ToString(blocks);
        sBlocks.Should().Be("""
                            OO#
                            O.O
                            ...
                            """);
    }

    [Fact]
    public void Part1()
    {
        var input = File.ReadAllText("Inputs/Day14.txt");
        int result = 0;
        for (int i = 0; i < 1000; i++)
        {
            result = Day14.Part1(input);
        }

        var timestamp = Stopwatch.GetTimestamp();

        result = Day14.Part1(input);
        //$"{Stopwatch.GetElapsedTime(timestamp)}".Should().Be("");

        Day14.Part1(input)
            .Should().Be(136);
    }

    [Fact]
    public void Part2()
    {
        var input = File.ReadAllText("Inputs/Day14.txt");
        int result = 0;
        for (int i = 0; i < 1000; i++)
        {
            result = Day14.Part1(input);
        }

        var timestamp = Stopwatch.GetTimestamp();

        result = Day14.Part1(input);
        //$"{Stopwatch.GetElapsedTime(timestamp)}".Should().Be("");

        Day14.Part1(input)
            .Should().Be(136);
    }
}


// O  [0] currentTop 
// .  [1]
// O  [2]
// .  [3]
// .  [4]
// O  [5]
// #  [6] <<<<
// .  [7] 
// O  [8]
// .  [9]