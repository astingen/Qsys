﻿using System;
using System.Collections.Generic;
using Crestron.SimplSharp;

namespace QscQsys
{
    public class QsysSnapshot : QsysComponent
    {
        public delegate void RecalledSnapshot(SimplSharpString cName, ushort snapshot);
        public delegate void UnrecalledSnapshot(SimplSharpString cName, ushort snapshot);
        public RecalledSnapshot onRecalledSnapshot { get; set; }
        public UnrecalledSnapshot onUnrecalledSnapshot { get; set; }

        public void Initialize(string coreId, string componentName)
        {
            var component = new Component(true)
            {
                Name = componentName,
                Controls = new List<ControlName>() 
                    { 
                        new ControlName() { Name = "load_1" }, 
                        new ControlName() { Name = "load_2" },
                        new ControlName() { Name = "load_3" },
                        new ControlName() { Name = "load_4" },
                        new ControlName() { Name = "load_5" },
                        new ControlName() { Name = "load_6" },
                        new ControlName() { Name = "load_7" },
                        new ControlName() { Name = "load_8" }
                    }
            };

            base.Initialize(coreId, component);
        }

        protected override void Component_OnNewEvent(object sender, QsysInternalEventsArgs e)
        {
            if(e.Name.Contains("load"))
            {
                var load = Convert.ToUInt16(e.Name.Split('_')[1]);

                if (e.Position == 1.0)
                {
                    if (onRecalledSnapshot != null)
                        onRecalledSnapshot(_cName, load);
                }
                else if (e.Position < 1.0)
                {
                    if (onUnrecalledSnapshot != null)
                        onUnrecalledSnapshot(_cName, load);
                }
            }
        }

        public void LoadSnapshot(ushort number)
        {
            if (_registered)
            {
                SendComponentChangeDoubleValue(string.Format("load_{0}", number), 1);
            }
        }

        public void SaveSnapshot(ushort number)
        {
            if (_registered)
            {
                SendComponentChangeDoubleValue(string.Format("save_{0}", number), number);
            }
        }
    }
}