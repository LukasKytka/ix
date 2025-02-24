CONFIGURATION MyConfiguration
    TASK Main(Interval := T#1000ms, Priority := 1);
    PROGRAM P1 WITH Main: MyProgram;

    VAR_GLOBAL
        Complex : ComplexForConfig;
        myBOOL	        :       BOOL	      ;
        myBYTE	        :       BYTE	      ;
        myWORD	        :       WORD	      ;
        myDWORD	        :       DWORD	      ;
        myLWORD	        :       LWORD	      ;
        mySINT	        :       SINT	      ;
        myINT	        :       INT	          ;
        myDINT	        :       DINT	      ;
        myLINT	        :       LINT	      ;
        myUSINT	        :       USINT	      ;
        myUINT	        :       UINT	      ;
        myUDINT	        :       UDINT	      ;
        myULINT	        :       ULINT	      ;
        myREAL	        :       REAL	      ;
        myLREAL	        :       LREAL	      ;
        myTIME	        :       TIME	      ;
        myLTIME	        :       LTIME	      ;
        myDATE	        :       DATE	      ;
        myLDATE	        :       LDATE	      ;
        myTIME_OF_DAY	:       TIME_OF_DAY	  ;
        myLTIME_OF_DAY	:       LTIME_OF_DAY  ;
        myDATE_AND_TIME  :       DATE_AND_TIME ;
        myLDATE_AND_TIME :       LDATE_AND_TIME;
        myCHAR	        :       CHAR	      ;
        myWCHAR	        :       WCHAR	      ;
        mySTRING	        :       STRING	      ;
        myWSTRING	    :       WSTRING	      ;

        {#ix-attr:[ReadOnce()]}
        myWSTRING_readOnce	    :       WSTRING	      ;
        {#ix-attr:[ReadOnly()]}
        myWSTRING_readOnly	    :       WSTRING	      ;
        {#ix-attr:[ReadOnce()]}
        cReadOnce           : ComplexForConfig;
        {#ix-attr:[ReadOnly()]}
        cReadOnly           : ComplexForConfig;
    END_VAR
END_CONFIGURATION

CLASS PUBLIC ComplexForConfig
    VAR PUBLIC
        myBOOL	        :       BOOL	      ;
        myBYTE	        :       BYTE	      ;
        myWORD	        :       WORD	      ;
        myDWORD	        :       DWORD	      ;
        myLWORD	        :       LWORD	      ;
        mySINT	        :       SINT	      ;
        myINT	        :       INT	          ;
        myDINT	        :       DINT	      ;
        myLINT	        :       LINT	      ;
        myUSINT	        :       USINT	      ;
        myUINT	        :       UINT	      ;
        myUDINT	        :       UDINT	      ;
        myULINT	        :       ULINT	      ;
        myREAL	        :       REAL	      ;
        myLREAL	        :       LREAL	      ;
        myTIME	        :       TIME	      ;
        myLTIME	        :       LTIME	      ;
        myDATE	        :       DATE	      ;
        myLDATE	        :       LDATE	      ;
        myTIME_OF_DAY	:       TIME_OF_DAY	  ;
        myLTIME_OF_DAY	:       LTIME_OF_DAY  ;
        myDATE_AND_TIME  :       DATE_AND_TIME ;
        myLDATE_AND_TIME :       LDATE_AND_TIME;
        myCHAR	        :       CHAR	      ;
        myWCHAR	        :       WCHAR	      ;
        mySTRING	        :       STRING	      ;
        myWSTRING	    :       WSTRING	      ;
    END_VAR    
END_CLASS    
