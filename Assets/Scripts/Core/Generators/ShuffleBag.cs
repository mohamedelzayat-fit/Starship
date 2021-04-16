using System;
using System.Collections.Generic;

namespace Starship.Core.Generators
{
    public class ShuffleBag<T>
    {
        private Random RandomGen { get; set; }
        private List<T> Data { get; set; }
        private T CurrentItem { get; set; }
        private int CurrentPosition { get; set; } = -1;
        public int Size => Data.Count;

        public ShuffleBag()
        {
            this.Data = new List<T>();
            this.RandomGen = new Random();
        }

        public ShuffleBag(T[] array)
        {
            this.Data = new List<T>(array);
            this.RandomGen = new Random();
        }

        public void Add(T item, int amount)
        {
            for (int i = 0; i < amount; i++)
                this.Data.Add(item);

            this.CurrentPosition = this.Size - 1;
        }

        public T Next()
        {
            if (this.Size == 0)
                return default(T);

            if (CurrentPosition < 0)
            {
                this.CurrentPosition = this.Size - 1;
                CurrentItem = this.Data[0];
                return CurrentItem;
            }

            var Position = this.RandomGen.Next(this.CurrentPosition);
            CurrentItem = this.Data[Position];
            this.Data[Position] = Data[CurrentPosition];
            this.Data[CurrentPosition] = CurrentItem;
            CurrentPosition--;

            return CurrentItem;
        }
    }    
}


