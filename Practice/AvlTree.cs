using System;
using System.Text;

namespace Practice
{
    public class AvlTree
    {
        public Node? Root { get; private set; }

        public void Insert(int value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int value)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraverse(Action<Node> traversalAction)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (Root == null)
            {
                return "[empty]";
            }
            
            if (Root.Height == 1)
            {
                return Root.Value.ToString();
            }

            // The bottom-most row in a tree of height n has 2^(n-1) nodes.

            // Assuming two-digit numbers at a max, each node takes up
            // 2 characters with an additional space between (3 total).

            // So the overall width of the structure is 3 * 2^(n-1)

            var width = 3 * (int)Math.Pow(2, Root.Height - 1);

            var totalHeight = Root.Height * 2 - 1;

            var output = new char[width, totalHeight];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < totalHeight; y++)
                {
                    output[x, y] = ' ';
                }
            }

            var rootIndentation = HeightIndentation(Root.Height);
            WriteNodeToString(Root, Root.Height, 0, rootIndentation, output, false);

            return AsSingleString(output);
        }

        private string AsSingleString(char[,] output)
        {
            var builder = new StringBuilder();

            for (var row = 0; row < output.GetLength(1); row++)
            {
                for (var column = 0; column < output.GetLength(0); column++)
                {
                    builder.Append(output[column, row]);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        private void WriteNodeToString(Node node, int height, int row, int column, char[,] output, bool left)
        {
            var valueAsString = node.Value.ToString();

            if (valueAsString.Length > 1 && !left)
            {
                for (var x = 0; x < valueAsString.Length; x++)
                {
                    output[column + x - 1, row] = valueAsString[x];
                }
            }
            else
            {
                for (var x = 0; x < valueAsString.Length; x++)
                {
                    output[column + x, row] = valueAsString[x];
                }
            }

            if ((node.LeftChild ?? node.RightChild) == null)
            {
                return;
            }

            var indentation = HeightIndentation(node.Height);
            var intentationDelta = indentation - HeightIndentation(node.Height - 1);

            output[column, row + 1] = '┴';

            if (node.LeftChild != null)
            {
                for (var x = 1; x < intentationDelta; x++)
                {
                    output[column - x, row + 1] = '-';
                }

                output[column - intentationDelta, row + 1] = '┌';

                WriteNodeToString(node.LeftChild, height - 1, row + 2, column - intentationDelta, output, true);
            }

            if (node.RightChild != null)
            {
                for (var x = 1; x < intentationDelta; x++)
                {
                    output[column + x, row + 1] = '-';
                }

                output[column + intentationDelta, row + 1] = '┐';

                WriteNodeToString(node.RightChild, height - 1, row + 2, column + intentationDelta, output, false);
            }
        }

        private static int HeightIndentation(int height)
        {
            if (height <= 0) // Needed to figure out indent of items below it (if any)
            {
                return 0;
            }
            else if (height == 1)
            {
                return 0;
            }
            else if (height == 2)
            {
                return 2;
            }
            else
            {
                return 2 * HeightIndentation(height - 1) + 1;
            }
        }

        public class Node
        {
            public int Value { get; }

            public Node? Parent { get; private set; }

            public Node? LeftChild { get; set; }

            public Node? RightChild { get; set; } 

            public int Height { get; }
        }
    }
}
