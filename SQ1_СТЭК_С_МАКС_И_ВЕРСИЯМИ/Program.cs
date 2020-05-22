using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new SizeStack<int>();
            for (int i = 0; i < n; i++)
                stack.Push(int.Parse(Console.ReadLine()));
            Console.WriteLine(stack.GetMax());
            Console.WriteLine(stack.GetMin());
            stack.RollBack(2);
            Console.WriteLine(stack.GetMax());
            Console.WriteLine(stack.GetMin());
        }
    }


    class StackItem<T>
    {
        public StackItem(T item)
        {
            Value = item;
        }

        public StackItem<T> PreviosItem;
        public StackItem<T> NextItem;
        public StackItem<T> SmalerItem;
        public StackItem<T> BigerItem;
        public T Value;
    }



    public class SizeStack<T>
        where T : IComparable
    {
        List<Snapshot<T>> rollbacks = new List<Snapshot<T>>();

        StackItem<T> lastItem;

        StackItem<T> firstItem;

        StackItem<T> minItem;

        StackItem<T> maxItem;



        public int Count { get; private set; }

        public void Push(T item)
        {
            var newItem = new StackItem<T>(item);
            if (Count == 0)
            {
                lastItem = firstItem = newItem;
                minItem = newItem;
                maxItem = newItem;
            }
            var curItem = maxItem;
            if (Count == 1)
            {
                if (curItem.Value.CompareTo(newItem.Value) > 0)
                    minItem = newItem;
                else
                    maxItem = newItem;
            }
            else
                while (minItem != curItem)
                {
                    if (curItem.Value.CompareTo(newItem.Value) > 0)
                    {
                        curItem = curItem.SmalerItem;
                    }
                    else
                    {
                        if (curItem == maxItem)
                        {
                            maxItem.BigerItem = newItem;
                            newItem.SmalerItem = maxItem;
                            maxItem = newItem;
                            break;
                        }
                        else
                        {
                            newItem.BigerItem = curItem.BigerItem;
                            curItem.BigerItem.SmalerItem = curItem;
                            curItem.BigerItem = newItem;
                            newItem.SmalerItem = curItem;
                            break;
                        }
                    }
                }

            if (minItem == curItem)
            {
                newItem.BigerItem = minItem;
                minItem.SmalerItem = newItem;
                minItem = newItem;
            }


            newItem.PreviosItem = lastItem;
            lastItem.NextItem = newItem;
            lastItem = newItem;
            Count++;
            rollbacks.Add(new Snapshot<T>(lastItem, firstItem, minItem, maxItem, Count));
        }

        public T GetMax()
        {
            return maxItem.Value;
        }

        public T GetMin()
        {
            return minItem.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception();

            var value = lastItem.Value;
            if (Count == 1)
            {
                lastItem = null;
                firstItem = null;
                minItem = null;
                maxItem = null;
            }
            else
            {
                lastItem.SmalerItem.BigerItem = lastItem.BigerItem;
                lastItem.BigerItem.SmalerItem = lastItem.SmalerItem;

                lastItem = lastItem.PreviosItem;
                lastItem.NextItem = null;
            }
            Count--;
            rollbacks.Add(new Snapshot<T>(lastItem, firstItem, minItem, maxItem, Count));
            return value;
        }

        public void RollBack(int index)
        {
            var snapshot = rollbacks[index];
            lastItem = snapshot.LastItem;
            firstItem = snapshot.FirstItem;
            minItem = snapshot.MinItem;
            maxItem = snapshot.MaxItem;
            Count = snapshot.Count;
            rollbacks.Add(new Snapshot<T>(lastItem, firstItem, minItem, maxItem, Count));
        }

        public void Forget()
        {
            rollbacks.Clear();
        }
    }

    class Snapshot<T>
    {
        public Snapshot(StackItem<T> lastItem, StackItem<T> firstItem, StackItem<T> minItem, StackItem<T> maxItem, int count)
        {
            LastItem = lastItem;
            FirstItem = firstItem;
            MinItem = minItem;
            MaxItem = maxItem;
            Count = count;
        }

        public readonly StackItem<T> LastItem;

        public readonly StackItem<T> FirstItem;

        public readonly StackItem<T> MinItem;

        public readonly StackItem<T> MaxItem;

        public readonly int Count;
    }
}
