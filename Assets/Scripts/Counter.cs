public class Counter
{
    private float _counter;
    private int _startingAmount { get; }

    public Counter(int value)
    {
        this._startingAmount = value;
        this._counter = this._startingAmount;
    }

    public float CurrentCounter(){
        return this._counter;
    }

    public float ChangeCounter(float amount)
    {
        this._counter += amount;
        if (this._counter < 0)
        {
            this._counter = 0;
        }
        return (int)this._counter;
    }

    public bool CounterFinished()
    {
        if (this._counter <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
