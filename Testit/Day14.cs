namespace Testit;

using System.Runtime.InteropServices;


public static class Blocks
{
    public static string ToString(Block[,] blocks)
    {
        var width = blocks.GetLength(0);
        var height = blocks.GetLength(1);
        var chars = new char[((width + Environment.NewLine.Length) * height) - Environment.NewLine.Length];

        int position = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                chars[position] = blocks[i, j] switch
                {
                    Block.Round => 'O',
                    Block.Cube => '#',
                    Block.None => '.'
                };
                position ++;
            }

            for (int j = 0; j < Environment.NewLine.Length && position < chars.Length; j++)
            {
                chars[position] = Environment.NewLine[j];
                position++;
            }
        }

        return new string(chars);
    }
}

public enum Block : byte
{
    None,
    Round,
    Cube,
}

public class Day14
{


    public static int Part1(string value)
    {
        var blocks = CreateBlock(value);
        var width = blocks.GetLength(0);
        var height = blocks.GetLength(1);

        for (var x = 0; x < width; x++)
        {
            var currentTop = 0;
            var roundRockCount = 0;
            for (var y = 0; y < height; y++)
            {
                var block = blocks[x, y];
                if (block == Block.Round)
                {
                    roundRockCount += 1;
                }
                else if (block == Block.Cube)
                {
                    MoveBlocks(
                        blocks,
                        currentTop,
                        roundRockCount,
                        x,
                        y);

                    currentTop = y + 1;
                    roundRockCount = 0;
                }
            }

            MoveBlocks(
                blocks,
                currentTop,
                roundRockCount,
                x,
                height);
        }

        var score = 0;
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            if (blocks[x, y] == Block.Round)
                score += height - y;
        }

        return score;
    }

    public static Block[,] CreateBlock(string value)
    {
        var lines = value.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;

        var blocks = new Block[width, height];
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
        {
            blocks[x, y] = lines[y][x] switch
            {
                'O' => Block.Round,
                '#' => Block.Cube,
                '.' => Block.None,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return blocks;
    }

    public static void MoveBlocks(
        Block[,] blocks,
        int currentTop,
        int roundRockCount,
        int currentX,
        int currentY)
    {
        for (var y = currentTop; y < currentY; y++)
        {
            if (roundRockCount > 0)
            {
                blocks[currentX, y] = Block.Round;
                roundRockCount -= 1;
            }
            else
            {
                blocks[currentX, y] = Block.None;
            }
        }
    }

    public static int Part2(string value)
    {
        var lines = value.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;

        var blocks = new Block[width, height];
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
        {
            blocks[x, y] = lines[y][x] switch
            {
                'O' => Block.Round,
                '#' => Block.Cube,
                '.' => Block.None,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        MoveNorth(width, height, blocks);
        MoveWest(width, height, blocks);
        MoveSouth(width, height, blocks);
        MoveEast(width, height, blocks);

        var score = 0;
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            if (blocks[x, y] == Block.Round)
                score += height - y;
        }

        return score;
    }

    public static void MoveEast(int width, int height, Block[,] blocks)
    {
        throw new NotImplementedException();
    }

    public static void MoveSouth(int width, int height, Block[,] blocks)
    {
        for (var x = 0; x < width; x++)
        {
            var currentTop = height - 1;
            var roundRockCount = 0;

            for (var y = height - 1; y >= 0; y--)
            {
                var block = blocks[x, y];
                if (block == Block.Round)
                {
                    roundRockCount += 1;
                }
                else if (block == Block.Cube)
                {
                    MoveBlocks(
                        blocks,
                        currentTop,
                        roundRockCount,
                        x,
                        y);

                    currentTop = y;
                    roundRockCount = 0;
                }
            }

            MoveBlocks(
                blocks,
                currentTop,
                roundRockCount,
                x,
                height);
        }
    }

    public static void MoveWest(int width, int height, Block[,] blocks)
    {
        throw new NotImplementedException();
    }

    public static void MoveNorth(int width, int height, Block[,] blocks)
    {
        for (var x = 0; x < width; x++)
        {
            var currentTop = 0;
            var roundRockCount = 0;

            for (var y = 0; y < height; y++)
            {
                var block = blocks[x, y];
                if (block == Block.Round)
                {
                    roundRockCount += 1;
                }
                else if (block == Block.Cube)
                {
                    MoveBlocks(
                        blocks,
                        currentTop,
                        roundRockCount,
                        x,
                        y);

                    currentTop = y + 1;
                    roundRockCount = 0;
                }
            }

            MoveBlocks(
                blocks,
                currentTop,
                roundRockCount,
                x,
                height);
        }
    }
}