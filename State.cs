using System;

// Context
class WaterHeater
{
    private IState state;

    public WaterHeater(IState state)
    {
        TransitionTo(state);
    }

    public void TransitionTo(IState state)
    {
        Console.WriteLine($"WaterHeater: Transition to {state.GetType().Name}");
        this.state = state;
        state.SetWaterHeater(this);
    }

    public void Heat()
    {
        state.HeatWater();
    }

    public void Cool()
    {
        state.CoolWater();
    }
}

// State interface
interface IState
{
    void SetWaterHeater(WaterHeater waterHeater);
    void HeatWater();
    void CoolWater();
}

// ConcreteState
class HeatingState : IState
{
    private WaterHeater waterHeater;

    public void SetWaterHeater(WaterHeater waterHeater)
    {
        this.waterHeater = waterHeater;
    }

    public void HeatWater()
    {
        Console.WriteLine("HeatingState: Heating water.");
    }

    public void CoolWater()
    {
        Console.WriteLine("HeatingState: Cannot cool water in heating mode.");
    }
}

// Another ConcreteState
class CoolingState : IState
{
    private WaterHeater waterHeater;

    public void SetWaterHeater(WaterHeater waterHeater)
    {
        this.waterHeater = waterHeater;
    }

    public void HeatWater()
    {
        Console.WriteLine("CoolingState: Cannot heat water in cooling mode.");
    }

    public void CoolWater()
    {
        Console.WriteLine("CoolingState: Cooling water.");
    }
}

class Program
{
    static void Main()
    {
        WaterHeater heater = new WaterHeater(new HeatingState());

        heater.Heat();
        heater.Cool();

        heater.TransitionTo(new CoolingState());
        heater.Heat();
        heater.Cool();
    }
}

