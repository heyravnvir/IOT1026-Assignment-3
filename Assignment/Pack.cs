﻿namespace Assignment
{
    // creating a pack class
    public class Pack
    {
        // i am using 1D array to store data 
        private InventoryItem[] _items; 

        // Maximum number of items pack can contain
        private readonly int _maxCount; 
        // Maximum volume of pack
        private readonly float _maxVolume; 
        // Maximum weight pack
        private readonly float _maxWeight; 

        // Total number of currently placed items in pack
        private int _currentCount; 

        // Current volume of pack
        private float _currentVolume; 

        // Current weight of pack
        private float _currentWeight; 

        // Default constructor to auto set the limits of pack
        public Pack() : this(10, 20, 30) { }

        // this is another contstructor that can be used to 
        // set the values acording to our needs if we dont want to use default values
        public Pack(int maxCount, float maxVolume, float maxWeight)
        {
            _items = new InventoryItem[maxCount];
            _maxCount = maxCount;
            _maxVolume = maxVolume;
            _maxWeight = maxWeight;
        }

        // Gettings the maximum values of pack
        public int GetMaxCount(){return _maxCount;}

        // getting the count of current items present in pack
        public int GetCurrentCount(){return _currentCount;}

        // this function is responsible for adding the items to the pack or array we can say
        public bool Add(InventoryItem item)
        {
            // getting the weight and volume of item
            float weight = item.GetWeight();
            float volume = item.GetVolume();
            // checking if there is any space left in pack or it is not overweight 
            if (volume <= _maxVolume){
                if ((volume + _currentVolume) < _maxVolume){
                    if ((weight + _currentWeight) < _maxWeight){
                        if (_currentCount < _maxCount){
                            // if the space is avalible then adding the weight of item to total weight of pack
                            // same with volume and items
                                _currentWeight += weight;
                                _currentVolume += volume;
                                _items[_currentCount++] = item;
                                return true;
                        }
                        else{
                             return false;
                        }
                    }
                    else{
                        return false;
                    }
                }
                else{
                    return false;
                }
            }
            else{
            // returning false if anything went wrong
            return false;
            }
            
        }

        // Overrides the ToString display information about the pack
        public override string ToString()
        {
            string packContents = $"------------------------------\nCurrent Items : {_currentCount} items,\nCurrent Weight : {_currentWeight}\nCurrent Volume : {_currentVolume}\n------------------------------";
            return packContents;
        }
    }

    public abstract class InventoryItem
    {
        private readonly float _volume, _weight;

        // this constructor is responsible of setting the volume and weight of item
        protected InventoryItem(float volume, float weight)
        {
            // checking if the weight and volume is not less than 0
            if (volume <= 0f || weight <= 0f)
            {
                // throwing error if it is less than 0
                throw new ArgumentOutOfRangeException($"An item can't have 0 weight or volume");
            }
            else{
                _volume = volume;
                _weight = weight;
            }
        }

        // this function is used to get the volume of the item
        public float GetVolume(){return _volume;}

        // this function is used to get the weight of the item
        public float GetWeight(){return _weight;}

        // displaying the information about item
        public abstract string Display();
    }

    // Arrow Class
    public class Arrow : InventoryItem{ 
    public Arrow() : base(0.05f, 0.1f) { }
    public override string Display(){
        return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Bow Class
    public class Bow : InventoryItem{
        public Bow() : base(4f, 1f) { }
    public override string Display()
        {
                return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Rope Class
    public class Rope : InventoryItem{public Rope() : base(1.5f, 1f) { 

    }

        public override string Display()
        {
            return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Water Class
    public class Water : InventoryItem
    {
        public Water() : base(3f, 2f) { }

        public override string Display()
        {
            return $"Water with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Food Class
    public class Food : InventoryItem
            {
                public Food() : base(0.5f, 1f) { }

                public override string Display()
            {
                return $"Food with weight {GetWeight()} and volume {GetVolume()}";
            }
        }

    // Sword Class
    public class Sword : InventoryItem{
        public Sword() : base(3f, 5f) { }
        public override string Display()
        {
            return $"A sword with weight {GetWeight()} and volume {GetVolume()}";
        }
    }
}