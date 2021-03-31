using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;

namespace CustomCollections
{
    /// <summary>
    /// A collection that is circular in nature. The first and last elements
    /// of this collection are considered neighbours. This collection only stores
    /// value types.
    /// </summary>
    class CircularStorage<T> where T : struct, IEquatable<T>, IComparable<T>
    {
        private T[] data;
        private uint count;
        private uint capacity;

        /// <summary>
        ///     Creates a new CircularStorage instance.
        /// </summary>
        /// <param name="limit">
        ///     The maximum number of elements that can be stored in the CircularStorage.
        /// </param>
        public CircularStorage(uint limit)
        {
            //=// INSERT CODE HERE
            capacity = limit;
            data = new T[capacity];
        }

        /// <summary>
        ///     Accesses the capacity of the CircularStorage (get only).
        /// </summary>
        //=// INSERT CODE HERE
        public uint Capacity
        {
            get { return capacity; }
        }

        /// <summary>
        ///     Accesses the number of elements in the CircularStorage (get only).
        /// </summary>
        //=// INSERT CODE HERE
        public uint Count
        {
            get { return count;  }
        }

        /// <summary>
        ///     Accesses an element of the CircularStorage by index. If the index exceeds
        ///     the limits of the CircularStorage, it will "wrap around".
        /// </summary>
        /// <param name="index">
        ///     The index of the element to be accessed.
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        ///     If CircularStorage instance is empty (has 0 elements):
        ///     *   Exception message will be "CircularStorage instance is empty.".
        /// </exception>
        /// <returns>
        ///     An access reference to the element of the CircularStorage.  
        /// </returns>
        public T this[int index]
        {
            get
            {
                //=// INSERT CODE HERE
                if (index >= capacity)
                {
                    return data[capacity - index];
                }
                    
                else
                {
                    return data[index];
                }

            }
            set
            {
                //=// INSERT CODE HERE
                if( capacity == 0)
                {
                    throw new IndexOutOfRangeException("CircularStorage instance is empty.");
                }
            }
        }

        /// <summary>
        ///     Adds an item to the start of the CircularStorage (all other elements 
        ///     are shift one element forward).
        /// </summary>
        /// <param name="item">
        ///     The item to be added.
        /// </param>
        /// <returns>
        ///     True if the item could be added (if there is still space in the 
        ///     CircularStorage), false otherwise.
        /// </returns>
        public bool Add(T item)
        {
            //=// INSERT CODE HERE
            if(count < capacity)
            {
                for(int x = (int)count; x>= 0; --x)
                {
                    try
                    {
                        data[x + 1] = data[x];
                    }
                    catch
                    {
                        Console.Write("Wrong");
                    }
                }
                data[0] = item;
                count += 1;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Remove the first instance of an item from the CircularStorage.
        /// </summary>
        /// <param name="item">
        ///     The item to be removed.
        /// </param>
        /// <returns>
        ///     True if the item was successfully removed, false otherwise (if 
        ///     the item does not exist it cannot be removed).
        /// </returns>
        public bool Remove(T item)
        {
            //=// INSERT CODE HERE
            try
            {
                int index = Array.IndexOf(data, item);
                List<T> temp = new List<T>(data);
                temp.RemoveAt(index);
                data = temp.ToArray();
                count -= 1;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Removes all instances of an item from the CircularStorage.
        /// </summary>
        /// <param name="item">
        ///     The item to be removed.
        /// </param>
        /// <returns>
        ///     True if the item was successfully removed, false otherwise (if 
        ///     the item does not exist it cannot be removed).
        /// </returns>
        public bool RemoveAll(T item)
        {
            //=// INSERT CODE HERE
            List<T> temp = new List<T>(data);
            int counts = 0;
            for (int x = 0; x < count; x++)
            {
                if (data[x].ToString() == item.ToString())
                {
                    temp.Remove(data[x]);
                    counts++;
                }
            }
            count -= (uint)counts;

            data = temp.ToArray();


                if (counts == 0)
                {
                return false;
            }
             else
                {
                    return true;
            }
        }

        /// <summary>
        ///     Shifts every element of the CircularStorage a specified number 
        ///     of steps in either direction.
        /// </summary>
        /// <param name="steps">
        ///     The number of steps to shift elements. Positive steps should 
        ///     shift elements to the right. Negative steps should shift 
        ///     elements to the left.
        /// </param>
        public void Rotate(int steps)
        {
            //=// INSERT CODE HERE
            List<T> tNumm = new List<T>();
            if (steps < 0)
            {

                steps = -steps;
                for (int x = 0; x < (int)count; ++x)
                {
                    if ((x + steps) >= count)
                    {
                        int f = (int)(x + steps - count);

                        while (f > count - 1)
                        {
                            f -= (int)count;
                            Console.WriteLine(f);
                        }
                        if (f <= count - 1)
                        {
                            tNumm.Add(data[f]);
                        }
                    }
                    else
                    {
                        tNumm.Add(data[x + steps]);
                    }
                }
            }
            else
            {
                for (int x = 0; x < (int)count; ++x)
                {
                    if ((x - steps) < 0)
                    {
                        int f = (int)(x - steps + count);
                        // Console.WriteLine(f);
                        while (f < 0)
                        {
                            f += (int)count;
                            //  Console.WriteLine(f);
                        }
                        if (f >= 0)
                        {
                            tNumm.Add(data[f]);
                        }
                    }
                    else
                    {
                        tNumm.Add(data[x - steps]);
                    }
                }
            }

            for (int x = 0; x < tNumm.Count; x++)
            {
                data[x] = tNumm[x];
            }
        }

        /// <summary>
        ///     Searches the CircularStorage for the first element that 
        ///     matches the predicate.
        /// </summary>
        /// <param name="predicate">
        ///     Predicate method used to search.
        /// </param>
        /// <returns>
        ///     The index of the first element that matches the predicate, if 
        ///     there are no matches it will return -1.
        /// </returns>
        public int Search(Predicate<T> predicate)
        {
            //=// INSERT CODE HERE
            List<T> temp = new List<T>(data);
            return temp.FindIndex(predicate);
        }

        /// <summary>
        ///     Searches and counts the CircularStorage for all elements that 
        ///     matches the predicate.
        /// </summary>
        /// <param name="predicate">
        ///     Predicate method used to search.
        /// </param>
        /// <returns>
        ///     The number of elements that match the predicate.
        /// </returns>
        public int SearchCount(Predicate<T> predicate)
        {
            //=// INSERT CODE HERE
            List<T> temp = new List<T>(data);

            List<int> numbers = new List<int>();

            List<T> temp2 = new List<T>(temp.FindAll(predicate));
            for (int x = 0; x < temp2.Count; x++)
            {

                numbers.Add(temp.IndexOf(temp2[x]));
            }
            return numbers.Count;
        }

        /// <summary>
        ///     Searches the CircularStorage for all elements that matches the 
        ///     predicate.
        /// </summary>
        /// <param name="predicate">
        ///     Predicate method used to search.
        /// </param>
        /// <returns>
        ///     An array of indices that match the predicate, if there are no 
        ///     matches it will return an empty array.
        /// </returns>
        public int[] SearchAll(Predicate<T> predicate)
        {
            //=// INSERT CODE
            List<T> temp = new List<T>(data);

            List<int> numbers = new List<int>();


            List<T> temp2 = new List<T>(temp.FindAll(predicate));
            for (int x = 0; x < temp2.Count; x++)
            {
                numbers.Add(temp.IndexOf(temp2[x]));
            }
            return numbers.ToArray();
        }

        /// <summary>
        ///     Returns a string representation of the CircularStorage using brace notation.
        /// </summary>
        /// <returns>
        ///     A string representation of the CircularStorage
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{ ");
            for (int i = 0; i < count; i++)
            {
                builder.Append(data[i]);
                if (i < count - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append(" }");
            return builder.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // You can change the type (int, bool, byte, etc...) and capacity here when experimenting 
            Driver<double> driver = new Driver<double>(10);
            driver.Execute();
        }
    }

    class Driver<T> where T : struct, IEquatable<T>, IComparable<T>
    {

        private uint capacity;
        private CircularStorage<T> collection;
        private TypeConverter converter;

        public Driver(uint capacity)
        {
            this.capacity = capacity;

            try
            {
                collection = new CircularStorage<T>(capacity);
                converter = TypeDescriptor.GetConverter(typeof(T));
            }
            catch (NotSupportedException)
            {
                Console.WriteLine($"Error: Type \'{typeof(T).Name}\' does not have a valid string converter, " +
                    $"please try a different type.");
                return;
            }
        }

        public void Execute()
        {
            Console.WriteLine(
                "Welcome to the CircularStorage test driver. Valid input is either a comment or a command.\n" +
                "A comment is any line in which a hash symbol appears as the first visible character.\n" +
                "A command is a space-separated list of tokens. Recognised commands are:\n" +
                "\tadd <value>\n" +
                "\tremove <value>\n" +
                "\tremoveAll <value>\n" +
                "\trotate <steps>\n" +
                "\tsearch <comparative operator> <value>\n" +
                "\tsearchAll <comparative operator> <value>\n" +
                "\tsearchCount <comparative operator> <value>\n" +
                "\tdisplay\n" +
                "\n" +
                "The follow comparative operators are valid:\n" +
                "\t== ~ Equals\n" +
                "\t!= ~ Not Equals\n" +
                "\t>= ~ Greater Than or Equals\n" +
                "\t<= ~ Less Than or Equals\n" +
                "\t>  ~ Greater Than\n" +
                "\t<  ~ Less Than\n" +
                "\n" +
                "Type: " + collection.GetType().GenericTypeArguments[0].Name + "\n" +
                "Capacity: " + capacity + "\n"
            );

            while (true)
            {
                Console.Write("===> ");
                string line = Console.ReadLine();

                if (line == null) break;

                line = line.Trim();

                // Check for empty line
                if (line.Length == 0) break;

                // Check for comment
                if (line[0] == (char)35) continue;

                string[] fields = line.Split();

                if (fields[0] == "quit") break;

                // Process a command
                try
                {
                    if (Add(fields)) continue;
                    if (Remove(fields)) continue;
                    if (RemoveAll(fields)) continue;
                    if (Rotate(fields)) continue;
                    if (Search(fields)) continue;
                    if (SearchAll(fields)) continue;
                    if (SearchCount(fields)) continue;
                    if (Display(fields)) continue;

                    // If all else fails:
                    Console.WriteLine($"Unknown command \'{string.Join(" ", fields)}\'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception caught - {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        private bool Display(string[] fields)
        {
            if (fields[0] != "display") return false;

            Console.WriteLine($"CircularStorage elements [{collection.Count}]:");
            Console.WriteLine("\t" + collection);
            return true;
        }

        private bool SearchCount(string[] fields)
        {
            if (fields[0] != "searchCount") return false;

            if (fields.Length < 3 ||
                !TryConvert(fields[2], out T value) ||
                !TryGetPredicate(fields[1], value, out Predicate<T> predicate)) return false;

            int count = collection.SearchCount(predicate);

            Console.WriteLine($"Found matching condition {count} times in the CircularStorage.");

            return true;
        }

        private bool SearchAll(string[] fields)
        {
            if (fields[0] != "searchAll") return false;

            if (fields.Length < 3 ||
                !TryConvert(fields[2], out T value) ||
                !TryGetPredicate(fields[1], value, out Predicate<T> predicate)) return false;

            int[] indices = collection.SearchAll(predicate);

            if (indices.Length != 0)
            {
                Console.WriteLine($"Successfully found matching condition at indices {string.Join(", ", indices)} of the CircularStorage.");
            }
            else
            {
                Console.WriteLine($"Failed to find matching condition in the CircularStorage.");
            }

            return true;
        }

        private bool Search(string[] fields)
        {
            if (fields[0] != "search") return false;

            if (fields.Length < 3 ||
                !TryConvert(fields[2], out T value) ||
                !TryGetPredicate(fields[1], value, out Predicate<T> predicate)) return false;

            int index = collection.Search(predicate);

            if (index != -1)
            {
                Console.WriteLine($"Successfully found matching condition at index {index} of the CircularStorage.");
            }
            else
            {
                Console.WriteLine($"Failed to find matching condition in the CircularStorage.");
            }

            return true;
        }

        private bool Rotate(string[] fields)
        {
            if (fields[0] != "rotate") return false;

            if (fields.Length < 2 || !int.TryParse(fields[1], out int steps)) return false;

            collection.Rotate(steps);

            Console.WriteLine($"Successfully rotated the CircularStorage by {steps} steps:");
            Console.WriteLine("\t" + collection);
            return true;
        }

        private bool RemoveAll(string[] fields)
        {
            if (fields[0] != "removeAll") return false;

            if (fields.Length < 2 || !TryConvert(fields[1], out T value)) return false;

            bool success = collection.RemoveAll(value);

            if (success)
            {
                Console.WriteLine($"Successfully removed all elements {value} from the CircularStorage:");
                Console.WriteLine("\t" + collection);
            }
            else
            {
                Console.WriteLine($"Unable to remove any elements {value} from the CircularStorage (missing).");
            }

            return true;
        }

        private bool Remove(string[] fields)
        {
            if (fields[0] != "remove") return false;

            if (fields.Length < 2 || !TryConvert(fields[1], out T value)) return false;

            bool success = collection.Remove(value);

            if (success)
            {
                Console.WriteLine($"Successfully removed first element {value} from the CircularStorage:");
                Console.WriteLine("\t" + collection);
            }
            else
            {
                Console.WriteLine($"Unable to remove element {value} from the CircularStorage (missing).");
            }

            return true;
        }

        private bool Add(string[] fields)
        {
            if (fields[0] != "add") return false;

            if (fields.Length < 2 || !TryConvert(fields[1], out T value)) return false;

            bool success = collection.Add(value);

            if (success)
            {
                Console.WriteLine($"Successfully added element {value} to the CircularStorage:");
                Console.WriteLine("\t" + collection);
            }
            else
            {
                Console.WriteLine($"Unable to add element {value} to CircularStorage (at capacity).");
            }

            return true;
        }

        private bool TryConvert(string input, out T result)
        {
            try
            {
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    result = (T)converter.ConvertFromString(input);
                    return true;
                }
                result = default;
                return false;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        private bool TryGetPredicate(string operatorString, T value, out Predicate<T> predicate)
        {
            switch (operatorString)
            {
                case "==":
                    predicate = (x) => { return x.Equals(value); };
                    break;
                case "!=":
                    predicate = (x) => { return !x.Equals(value); };
                    break;
                case ">=":
                    predicate = (x) => { return x.CompareTo(value) >= 0; };
                    break;
                case "<=":
                    predicate = (x) => { return x.CompareTo(value) <= 0; };
                    break;
                case ">":
                    predicate = (x) => { return x.CompareTo(value) > 0; };
                    break;
                case "<":
                    predicate = (x) => { return x.CompareTo(value) < 0; };
                    break;
                default:
                    predicate = default;
                    return false;
            }
            return true;
        }
    }
}
