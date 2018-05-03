using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;

namespace InkExamples.MyInks
{
    public abstract class InkObject : DynamicRenderer
    {
        public MyInkCanvas myInkCanvas { get;private set; }
        public InkObjectStroke InkStroke { get;protected set; }
        public InkType inkType { get; protected set; }
        public MyInkData inkTool;
        public DrawingAttributes inkDA;
        protected Point perviousPoint;
        private bool isInkColorAtEnd = true;

        public abstract void CreateNewStrokes();

        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            base.OnStylusDown(rawStylusInput);
        }

        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            base.OnStylusUp(rawStylusInput);
            this.InkStroke = null;
        }

    }

    public class InkObjectStroke : Stroke
    {
        protected InkObject ink;
        public MyInkData inkTool;

        public InkObjectStroke(InkObject ink, StylusPointCollection stylusPoints)
            : base(stylusPoints)
        {
            this.ink = ink;
            //inkTool = ink.CreateFromInkData(ink.inkTool);
            //this.DrawingAttributes = ink.inkDA.Clone();
            //this.DrawingAttributes.Color = ink.myInkCanvas.fillColor;
        }

        protected virtual void RemoveDirtyStylusPoints()
        {
            if (StylusPoints.Count > 2)
            {
                for (int i = StylusPoints.Count - 2; i > 0; i--)
                {
                    StylusPoints.RemoveAt(i);
                }
            }
        }
    }
}
