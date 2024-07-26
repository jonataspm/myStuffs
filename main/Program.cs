

#region Questão 779 - HARD

//Console.WriteLine(Solution.CountOfAtoms("H2O"));
//Console.WriteLine(Solution.CountOfAtoms("Mg(OH)2"));
//Console.WriteLine(Solution.CountOfAtoms("K4(ON(SO3)2)2"));
//Console.WriteLine(Solution.CountOfAtoms("((N42)24(OB40Li30CHe3O48LiNN26)33(C12Li48N30H13HBe31)21(BHN30Li26BCBe47N40)15(H5)16)14"));
//Console.WriteLine(Solution.CountOfAtoms("(N13O9Be)37(LiC50B35)38(Li33HHBe14He5ON50N)27(H3C)2He14C34Li33C33He15N14N5Li24Li17H28O13H42(HeHe6CO11Li)35(He3O27HO5N21H49O39CH37B3)8(O41He27He46He22He17)12"));

#endregion

#region Questão Questão 1334 - Medium

//Input: n = 4, edges = [[0,1,3],[1,2,1],[1,3,4],[2,3,1]], distanceThreshold = 4
using System.Runtime.Intrinsics.X86;

var edges1 = new int[][]
{
    new int[] {0,1,3},
    new int[] {1,2,1},
    new int[] {1,3,4},
    new int[] {2,3,1},
};
Console.WriteLine(Solution.FindTheCity(4, edges1, 4));


//Input: n = 5, edges = [[0,1,2],[0,4,8],[1,2,3],[1,4,2],[2,3,1],[3,4,1]], distanceThreshold = 2
var edges2 = new int[][]
{
    new int[] {0,1,2},
    new int[] {0,4,8},
    new int[] {1,2,3},
    new int[] {1,4,2},
    new int[] {2,3,1},
    new int[] {3,4,1}
};
Console.WriteLine(Solution.FindTheCity(5, edges2, 2));


//Input: n = 6, edges = [[0,3,7],[2,4,1],[0,1,5],[2,3,10],[1,3,6],[1,2,1]], distanceThreshold = 417
var edges3 = new int[][]
{
    new int[] {0,3,7},
    new int[] {2,4,1},
    new int[] {0,1,5},
    new int[] {2,3,10},
    new int[] {1,3,6},
    new int[] {1,2,1}
};
Console.WriteLine(Solution.FindTheCity(6, edges3, 417));

//Input: n = 6 edges = [[0, 1, 10],[0,2,1],[2,3,1],[1,3,1],[1,4,1],[4,5,10]] distanceThreshold = 20 
var edges4 = new int[][]
{
    new int[] {0,1,10},
    new int[] {0,2,1},
    new int[] {2,3,1},
    new int[] {1,3,1},
    new int[] {1,4,1},
    new int[] {4,5,10},
};
Console.WriteLine(Solution.FindTheCity(6, edges4, 20));

#endregion

#region Questão
#endregion

#region Questão
#endregion


Console.ReadKey();