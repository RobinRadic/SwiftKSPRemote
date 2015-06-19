using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ScintillaNET;

namespace SwiftTest
{
    public static class EditorExtensions
    {
        // https://github.com/jacobslusser/ScintillaNET/blob/master/ScintillaNET/NativeMethods.cs
        public const int SCI_SETFOLDLEVEL = 2222;
        public const int SCI_GETFOLDLEVEL = 2223;
        public const int SCI_GETLASTCHILD = 2224;
        public const int SCI_GETFOLDPARENT = 2225;
        public const int SCI_SHOWLINES = 2226;
        public const int SCI_HIDELINES = 2227;
        public const int SCI_GETLINEVISIBLE = 2228;
        public const int SCI_GETALLLINESVISIBLE = 2236;
        public const int SCI_SETFOLDEXPANDED = 2229;
        public const int SCI_GETFOLDEXPANDED = 2230;
        public const int SCI_TOGGLEFOLD = 2231;
        public const int SCI_FOLDLINE = 2237;
        public const int SCI_FOLDCHILDREN = 2238;
        public const int SCI_EXPANDCHILDREN = 2239;
        public const int SCI_FOLDALL = 2662;
        public const int SCI_ENSUREVISIBLE = 2232;
        public const int SCI_SETAUTOMATICFOLD = 2663;
        public const int SCI_GETAUTOMATICFOLD = 2664;
        public const int SCI_SETFOLDFLAGS = 2233;

        public const int SC_FOLDLEVELBASE = 1024;
        public const int SC_FOLDLEVEL = 1024;

        public const int SC_FOLDLEVELNUMBERMASK = 4095;

        public enum FoldAction
        {
            CONTRACT = 0,
            EXPAND = 1,
            TOGGLE = 2
        }

        public enum FoldLevel
        {
         SC_FOLDLEVELBASE=0x400,
         SC_FOLDLEVELWHITEFLAG=0x1000,
         SC_FOLDLEVELHEADERFLAG=0x2000,
         SC_FOLDLEVELBOXHEADERFLAG=0x4000,
         SC_FOLDLEVELBOXFOOTERFLAG=0x8000,
         SC_FOLDLEVELCONTRACTED=0x10000,
         SC_FOLDLEVELUNINDENT=0x20000,
         SC_FOLDLEVELNUMBERMASK=0x0FFF,
            
        }

        public static void ToggleFold(this Scintilla editor, int line)
        {
            editor.DirectMessage(SCI_TOGGLEFOLD, new IntPtr(line), IntPtr.Zero);



        }

        public static void TestFold(this Scintilla editor)
        {
            int line = editor.CurrentLineNr();
            Debug.WriteLine("GetFoldLevel: " + editor.GetFoldLevel(line));
            Debug.WriteLine("IsFoldLine: " + editor.IsFoldLine(line));
            int pl = editor.GetFoldParentLine(line);
            Debug.WriteLine("GetFoldParentLine: " + pl);
            Debug.WriteLine("GetFoldParentLine - IsFoldLine: " + editor.IsFoldLine(pl));
        }

        public static bool IsFoldLine(this Scintilla editor, int line)
        {
            var level = editor.DirectMessage(SCI_GETFOLDLEVEL, new IntPtr(line), IntPtr.Zero).ToInt32();
            level &= (int)FoldLevel.SC_FOLDLEVELHEADERFLAG;
            return level > 0;
        }

        public static int GetFoldLevel(this Scintilla editor, int line)
        {
            var level = editor.DirectMessage(SCI_GETFOLDLEVEL, new IntPtr(line), IntPtr.Zero).ToInt32();
            level &= (int)FoldLevel.SC_FOLDLEVELNUMBERMASK;
            level -= (int)FoldLevel.SC_FOLDLEVELBASE;
            return level;
        }

        public static int GetFoldParentLine(this Scintilla editor, int line)
        {
            return editor.DirectMessage(SCI_GETFOLDPARENT, new IntPtr(line), IntPtr.Zero).ToInt32();
        }

        public static void FoldLine(this Scintilla editor, int line, FoldAction action)
        {
            editor.DirectMessage(SCI_FOLDLINE, new IntPtr(line), new IntPtr((int)action));
        }

        public static void FoldAll(this Scintilla editor, int line, FoldAction action)
        {
            editor.DirectMessage(SCI_FOLDALL, new IntPtr(line), new IntPtr((int)action));
        }

        public static void FoldChildren(this Scintilla editor, int line, FoldAction action)
        {
            editor.DirectMessage(SCI_FOLDCHILDREN, new IntPtr(line), new IntPtr((int)action));
        }

        public static Line CurrentLine(this Scintilla editor)
        {
            return editor.Lines[editor.CurrentLineNr()];
        }
        public static int CurrentLineNr(this Scintilla editor)
        {
            return editor.LineFromPosition(editor.CurrentPosition);
        }
    }
}
