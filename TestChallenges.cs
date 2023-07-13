using System.Collections;
using NUnit.Framework;

namespace consolidation_csharp_lesson_7;

public class TestChallenges
{
    [SetUp]
    public void Setup()
    {
    }

    public static IEnumerable MinimumKnightHopsTestCases
    {
        get
        {
            yield return new TestCaseData((4, 4), (4, 4), 0);
            yield return new TestCaseData((7, 6), (4, 3), 2);
            yield return new TestCaseData((6, 4), (6, 5), 3);
        }
    }

    [Test, TestCaseSource(nameof(MinimumKnightHopsTestCases))]
    public void CalculateMinimumKnightHopsUsingBfs(
        (int, int) start, (int, int) end, int expectedMinimumHops)
    {
        int minimumHops = MazeSolver.CalculateMinimumKnightHopsUsingBFS(start, end);
        Assert.AreEqual(expectedMinimumHops, minimumHops,
            $"The path from {start} to {end} should have taken {expectedMinimumHops} hops");
    }

    public static IEnumerable CheckEndReachableFromStartInMazeUsingDfsTestCases
    {
        get
        {
            yield return new TestCaseData(
                new List<List<Square>>
                {
                    new() { Square.Space, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space },
                    new() { Square.Space, Square.Space, Square.Space, Square.Wall, Square.Wall, Square.Space, Square.Space },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Wall, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall }
                },
                (0, 0),
                (0, 6),
                true
            );

            yield return new TestCaseData(
                new List<List<Square>>
                {
                    new() { Square.Space, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space },
                    new() { Square.Space, Square.Space, Square.Space, Square.Wall, Square.Wall, Square.Space, Square.Space },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Wall, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall }
                },
                (0, 0),
                (0, 6),
                false
            );
        }
    }

    [Test, TestCaseSource(nameof(CheckEndReachableFromStartInMazeUsingDfsTestCases))]
    public void CheckEndReachableFromStartInMazeUsingDfs(
        List<List<Square>> maze, (int, int) start, (int, int) end, bool expectedReachabilityResult)
    {
        bool reachabilityResult = MazeSolver.CheckEndReachableFromStartInMazeUsingDFS(maze, start, end);
        Assert.AreEqual(expectedReachabilityResult, reachabilityResult,
            $"Expected end to {(expectedReachabilityResult ? "be" : "not be")} reachable from start");
    }

    public static IEnumerable FindLengthOfShortestPathInMazeUsingBfsTestCases
    {
        get
        {
            yield return new TestCaseData(
                new List<List<Square>>
                {
                    new() { Square.Space, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space },
                    new() { Square.Space, Square.Space, Square.Space, Square.Space, Square.Wall, Square.Space, Square.Space },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Wall, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall }
                },
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 6),
                10
            );

            yield return new TestCaseData(
                new List<List<Square>>
                {
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall },
                    new() { Square.Wall, Square.Space, Square.Space, Square.Wall, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Space, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Space, Square.Space, Square.Wall, Square.Wall, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Space, Square.Wall },
                    new() { Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall }
                },
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 4),
                11
            );
        }
    }

    [Test, TestCaseSource(nameof(FindLengthOfShortestPathInMazeUsingBfsTestCases))]
    public void FindLengthOfShortestPathInMazeUsingBfs(
        List<List<Square>> maze, Tuple<int, int> start, Tuple<int, int> end, int expectedShortestPathLength)
    {
        int shortestPathLength = MazeSolver.FindLengthOfShortestPathInMazeUsingBFS(maze, start.ToValueTuple(), end.ToValueTuple());
        Assert.AreEqual(expectedShortestPathLength, shortestPathLength,
            $"Shortest path through maze should have been {expectedShortestPathLength} steps long");
    }

    [Test]
    public void FindLengthOfShortestPathInMazeUsingBFSWithNoValidPath()
    {
        var maze = new List<List<Square>>
            {
                new() { Square.Space, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space },
                new() { Square.Space, Square.Space, Square.Space, Square.Wall, Square.Wall, Square.Space, Square.Space },
                new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Wall, Square.Space, Square.Wall },
                new() { Square.Wall, Square.Wall, Square.Wall, Square.Space, Square.Space, Square.Space, Square.Wall },
                new() { Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall, Square.Wall }
            };

        var start = (0, 0);
        var end = (0, 6);
        var expectedExceptionMessage = "End not reachable from start";

        Assert.Throws<ArgumentException>(() =>
        {
            MazeSolver.FindLengthOfShortestPathInMazeUsingBFS(maze, start, end);
        }, expectedExceptionMessage);
    }

    [Test]
    public void FindLengthOfLongestDownhillPathUsingBFS()
    {
        // Test case 1
        var altitudes1 = new List<List<int>>
        {
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 8, 8, 8, 8, 9, 9, 9, 9 },
            new() { 9, 9, 6, 5, 7, 8, 8, 9, 9, 9 },
            new() { 9, 8, 7, 9, 7, 8, 9, 9, 9, 9 },
            new() { 9, 9, 8, 7, 8, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 8, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }
        };

        var start1 = (3, 1);
        var expectedLongestPathLength1 = 4;

        int longestPathLength1 = MazeSolver.FindLengthOfLongestDownhillPathUsingBFS(altitudes1, start1);
        Assert.AreEqual(expectedLongestPathLength1, longestPathLength1);

        // Test case 2
        var altitudes2 = new List<List<int>>
        {
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 8, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 6, 7, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 5, 4, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }
        };

        var start2 = (3, 3);
        var expectedLongestPathLength2 = 5;

        int longestPathLength2 = MazeSolver.FindLengthOfLongestDownhillPathUsingBFS(altitudes2, start2);
        Assert.AreEqual(expectedLongestPathLength2, longestPathLength2);
    }

    public static IEnumerable TestFloodFillTestCases
    {
        get
        {
            yield return new TestCaseData(
                new List<List<string>>
                {
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "B", "B", "W", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "W", "B", "B", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                },
                (3, 4),
                "R",
                new List<List<string>>
                {
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "R", "R", "W", "W", "W" },
                    new() { "W", "W", "R", "R", "R", "R", "W", "W" },
                    new() { "W", "W", "R", "R", "R", "R", "W", "W" },
                    new() { "W", "W", "R", "R", "R", "R", "W", "W" },
                    new() { "W", "W", "W", "R", "R", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                }
            );

            yield return new TestCaseData(
                new List<List<string>>
                {
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "B", "B", "W", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "W", "B", "B", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                },
                (3, 4),
                "B",
                new List<List<string>>
                {
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                    new() { "W", "W", "W", "B", "B", "W", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "B", "B", "B", "B", "W", "W" },
                    new() { "W", "W", "W", "B", "B", "W", "W", "W" },
                    new() { "W", "W", "W", "W", "W", "W", "W", "W" },
                }
            );
        }
    }

    [Test, TestCaseSource(nameof(TestFloodFillTestCases))]
    public void TestFloodFillUsingBFS(List<List<string>> pixels, (int, int) start, string replacementValue, List<List<string>> expectedFilledPixels)
    {
        MazeSolver.FloodFillUsingBFS(pixels, start, replacementValue);
        for (int i = 0; i < pixels.Count; i++)
        {
            CollectionAssert.AreEqual(pixels[i], expectedFilledPixels[i]);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestFloodFillTestCases))]
    public void TestFloodFillUsingDfs(
        List<List<string>> pixels, (int, int) start, string replacementValue,
        List<List<string>> expectedFilledPixels)
    {
        MazeSolver.FloodFillUsingDFS(pixels, start, replacementValue);
        for (int i = 0; i < pixels.Count; i++)
        {
            CollectionAssert.AreEqual(pixels[i], expectedFilledPixels[i]);
        }
    }

    public static IEnumerable TestCountIslandsTestCases
    {
        get
        {
            yield return new TestCaseData(
                new List<List<string>>
                {
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", " ", " " },
                },
                0
            );

            yield return new TestCaseData(
                new List<List<string>>
                {
                    new List<string> { " ", "X", " ", " ", " ", " ", " ", " " },
                    new List<string> { " ", "X", " ", " ", " ", " ", "X", " " },
                    new List<string> { " ", " ", " ", "X", "X", " ", " ", " " },
                    new List<string> { " ", " ", " ", "X", "X", " ", " ", " " },
                    new List<string> { "X", "X", " ", " ", " ", "X", " ", " " },
                    new List<string> { " ", "X", "X", " ", " ", " ", "X", "X" },
                    new List<string> { " ", " ", "X", " ", " ", " ", "X", " " },
                    new List<string> { " ", " ", " ", " ", " ", " ", "X", " " },
                },
                6
            );
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCountIslandsTestCases))]
    public void TestCountIslandsUsingBfs(
        List<List<string>> landscape, int expectedIslandCount)
    {
        var result = MazeSolver.CountNumberOfIslandsUsingBFS(landscape);
        Assert.AreEqual(result, expectedIslandCount);
    }

    [Test]
    [TestCaseSource(nameof(TestCountIslandsTestCases))]
    public void TestCountIslandsUsingDfs(
        List<List<string>> landscape, int expectedIslandCount)
    {
        var result = MazeSolver.CountNumberOfIslandsUsingDFS(landscape);
        Assert.AreEqual(result, expectedIslandCount);
    }

    [Test]
    public void TestFileTreePrintUsingDFS()
    {
        var file = new FileTreeNode("file.txt");
        var fileTree = new FileTree(file);

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            fileTree.PrintUsingDFS();

            var expectedOutput = "file.txt";
            var actualOutput = sw.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void TestFileTreePrintUsingDFSComplexExample()
    {
        var dir1 = new DirectoryNode("dir1");
        var dir2 = new DirectoryNode("dir2");
        var dir3 = new DirectoryNode("dir3");
        var file1 = new FileTreeNode("file1.txt");
        var file2 = new FileTreeNode("file2.txt");
        var file3 = new FileTreeNode("file3.txt");
        dir1.AddChild(dir2);
        dir1.AddChild(file1);
        dir1.AddChild(dir3);
        dir2.AddChild(file2);
        dir3.AddChild(file3);

        var fileTree = new FileTree(dir1);

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            fileTree.PrintUsingDFS();

            var expectedOutput = new[]
            {
                "dir1/",
                "   -> dir2/",
                "      -> file2.txt",
                "   -> file1.txt",
                "   -> dir3/",
                "      -> file3.txt",
            };
            var actualOutput = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }
    }
}