CLASS testingProgram
    VAR PUBLIC
        {#ix-set:AttributeName = "instanceOfStPrimitive"}
        {#ix-attr:[Container(Layout.Wrap)]}
        testPrimitive: stTestPrimitive;
        {#ix-set:AttributeName = "instanceOfStPrimitive"}
        {#ix-attr:[Container(Layout.Border)]}
        testComplex: stTestComplex; 
        {#ix-set:AttributeName = "instanceOfStEnum"}
        testEnum: stTestEnum;
        {#ix-attr:[Container(Layout.UniformGrid)]}
        testRenderIgnore : stTestRenderIgnore;
        
        testEmpty: TestEmpty;
        testLayoutOverwrite: TestLayoutOverwriting;
        testMixed : TestMixed;
        testMultipleLayouts: TestMultipleLayouts;
        testSimple: TestSimple;
        testWithoutLayouts: TestWithoutLayouts;
        testSimpleNested: TestSimpleNested;
        {#ix-attr:[Container(Layout.Tabs)]}
        testMultipleNested: stTestMultipleNested;
    END_VAR
    
END_CLASS