using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using QscQsys;
using ExtensionMethods;
using TCP_Client;

namespace UserModule_QSYS_GENERIC_INTEGER_NAMED_CONTROL
{
    public class UserModuleClass_QSYS_GENERIC_INTEGER_NAMED_CONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput SETINTEGERVALUE;
        Crestron.Logos.SplusObjects.AnalogOutput INTEGERVALUE;
        StringParameter NAMEDCONTROLNAME;
        ShortParameter MAXVALUE;
        ShortParameter MINVALUE;
        QscQsys.QsysNamedControlSimpl INTEGERCONTROL;
        object SETINTEGERVALUE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort X = 0;
                
                
                __context__.SourceCodeLine = 19;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SETINTEGERVALUE  .UshortValue == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 21;
                    INTEGERCONTROL . SetInteger ( (ushort)( 0 )) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 25;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt (X != SETINTEGERVALUE  .UshortValue))  ) ) 
                        { 
                        __context__.SourceCodeLine = 27;
                        X = (ushort) ( SETINTEGERVALUE  .UshortValue ) ; 
                        __context__.SourceCodeLine = 28;
                        INTEGERCONTROL . SetInteger ( (ushort)( X )) ; 
                        __context__.SourceCodeLine = 25;
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void NEWINTEGERCHANGE ( ushort VALUE , SimplSharpString X ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
            
            __context__.SourceCodeLine = 35;
            INTEGERVALUE  .Value = (ushort) ( VALUE ) ; 
            
            
        }
        finally { ObjectFinallyHandler(); }
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 40;
            // RegisterDelegate( INTEGERCONTROL , NEWNAMEDCONTROLCHANGE , NEWINTEGERCHANGE ) 
            INTEGERCONTROL .newNamedControlChange  = NEWINTEGERCHANGE; ; 
            __context__.SourceCodeLine = 41;
            INTEGERCONTROL . Initialize ( NAMEDCONTROLNAME  .ToString(), (short)( MAXVALUE  .Value ), (short)( MINVALUE  .Value )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        SETINTEGERVALUE = new Crestron.Logos.SplusObjects.AnalogInput( SETINTEGERVALUE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( SETINTEGERVALUE__AnalogSerialInput__, SETINTEGERVALUE );
        
        INTEGERVALUE = new Crestron.Logos.SplusObjects.AnalogOutput( INTEGERVALUE__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( INTEGERVALUE__AnalogSerialOutput__, INTEGERVALUE );
        
        MAXVALUE = new ShortParameter( MAXVALUE__Parameter__, this );
        m_ParameterList.Add( MAXVALUE__Parameter__, MAXVALUE );
        
        MINVALUE = new ShortParameter( MINVALUE__Parameter__, this );
        m_ParameterList.Add( MINVALUE__Parameter__, MINVALUE );
        
        NAMEDCONTROLNAME = new StringParameter( NAMEDCONTROLNAME__Parameter__, this );
        m_ParameterList.Add( NAMEDCONTROLNAME__Parameter__, NAMEDCONTROLNAME );
        
        
        SETINTEGERVALUE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SETINTEGERVALUE_OnChange_0, true ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        INTEGERCONTROL  = new QscQsys.QsysNamedControlSimpl();
        
        
    }
    
    public UserModuleClass_QSYS_GENERIC_INTEGER_NAMED_CONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint SETINTEGERVALUE__AnalogSerialInput__ = 0;
    const uint INTEGERVALUE__AnalogSerialOutput__ = 0;
    const uint NAMEDCONTROLNAME__Parameter__ = 10;
    const uint MAXVALUE__Parameter__ = 11;
    const uint MINVALUE__Parameter__ = 12;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}