using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    //Context
    public class Clock
    {
        private ClockState currentState;
        public int Hours { get; set; }
        public int Minutes { get;set; }

        public Clock()
        {
            ChangeState(new NormalState(this));
        }

        public ClockState GetCurrentState()
        {
            return currentState;
        }

        public void ChangeState(ClockState cs)
        {
            this.currentState = cs;
        }

        public void ModeButton()
        {
            currentState.Mode();
        }

        public void ChangeButton()
        {
            currentState.Change();
        }
    }

    public abstract class ClockState
    {
        protected Clock clock;

        public ClockState(Clock clock)
        {
            this.clock = clock;
        }
        public abstract void Mode();
        public abstract void Change();
    }

    public class NormalState: ClockState
    {
        public NormalState(Clock c):base(c)
        {
            Console.WriteLine("Orologio in modalità normale");
        }

        public override void Change()
        {
            Console.WriteLine("Orologio in modalità normale, Change non ha alcun effetto");
        }

        public override void Mode()
        {
            clock.ChangeState(new ModificaOreState(clock));
        }
    }

    public class ModificaOreState: ClockState
    {
        public ModificaOreState(Clock c) : base(c)
        {
            Console.WriteLine("Orologio in modalità modifica ore");
        }

        public override void Change()
        {
            clock.Hours++;
            clock.Hours = clock.Hours % 24;
        }

        public override void Mode()
        {
            clock.ChangeState(new ModificaMinutiState(clock));
        }
    }

    public class ModificaMinutiState : ClockState
    {
        public ModificaMinutiState(Clock c) : base(c)
        {
            Console.WriteLine("Orologio in modalità modifica minuti");
        }

        public override void Change()
        {
            clock.Minutes++;
            clock.Minutes = clock.Minutes % 60;
        }

        public override void Mode()
        {
            clock.ChangeState(new NormalState(clock));
        }
    }
}
