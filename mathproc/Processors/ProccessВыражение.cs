using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathproc.Processors
{
    public class ProccessВыражение : IProcessor
    {
        public bool Proccess(string atom, AbstractTreeItem seed, out AbstractTreeItem item)
        {
            MathExpr[] exprs = null;
            item= new TreeItem();
            item.Type=TreeItemType.Выражение;
            string polska = null;
            try
            {
                polska = GetPolskaFormat(atom, out exprs);
            }
            catch (MpException e)
            {
                item.Error = true;
                item.ErrorCode = e.Code;
            }
            catch (Exception e)
            {
                item.Error = true;
                item.ErrorCode = ErrorCodes.Unknown;
            }
            throw new NotImplementedException();

        }

        public MathExpr[] GetMathExprs(string atom)
        {
            var priority0 = "+;-;";
            var priority1 = "*;/;%;";
            var priority2 = "*^";

            var priority0ar = priority0.Split(new char[] { ';' }, StringSplitOptions.None);
            var priority1ar = priority1.Split(new char[] { ';' }, StringSplitOptions.None);
            var priority2ar = priority2.Split(new char[] { ';' }, StringSplitOptions.None);

            var op = (priority0 + priority1 + priority2).Split(new char[] { ';' }, StringSplitOptions.None);
            var digits = "0123456789";

            var open = atom.Count(c => c == '(');
            var close = atom.Count(c => c == ')');

            if (open == close)
            {
                var priority = 0;
                MathExpr expr = null;
                var all = new List<MathExpr>();
                for (int i = 0; i < atom.Length; i++)
                {
                    var c = atom[i];
                    if (expr == null)
                    {
                        expr = new MathExpr();
                    }
                    
                    if (c == '(')
                    {
                        //expr.Left += c;
                        priority++;
                    }
                    else if (c == ')')
                    {
                        //expr.Left += c;
                        priority--;
                    }
                    else if (op.Any(a => a == c.ToString()))
                    {
                        if (string.IsNullOrEmpty(expr.Left))
                        {
                            if (c == '-' || c == '+')
                            {
                                expr.Left += c;
                            }
                            else
                            {
                                throw new MpException(MpException.GetMessage(ErrorCodes.TP_Выражения1),
                                    ErrorCodes.TP_Выражения1);
                            }
                        }
                        else if (!string.IsNullOrEmpty(expr.Left) && expr.Operator == null)
                        {
                            expr.Operator = c.ToString();
                            expr.Priority = priority;
                            if (priority0ar.Any(a => a == c.ToString()))
                                expr.OperatorPriority = 0;
                            else if (priority1ar.Any(a => a == c.ToString()))
                                expr.OperatorPriority = 1;
                            else
                            {
                                var c1 = c;
                                if (priority2ar.Any(a => a == c1.ToString()))
                                    expr.OperatorPriority = 2;
                                else
                                {
                                    throw new MpException(MpException.GetMessage(ErrorCodes.TP_Выражения2),
                                    ErrorCodes.TP_Выражения2);
                                }
                            }
                            all.Add(expr);
                            expr = null;
                        }
                    }
                    else
                    {
                        if (digits.Contains(c))
                        {
                            expr.Left += c;
                        }
                        else
                        {
                            //поиск переменной или функции
                            expr.Left += c;
                        }
                    }

                    if (i == atom.Length - 1)
                    {
                        all.Add(expr);
                        expr = null;
                    }
                }
                return all.ToArray();
            }
            else
            {
                throw new MpException(MpException.GetMessage(ErrorCodes.TP_Выражения3),
                                    ErrorCodes.TP_Выражения3);
            }
            throw new NotImplementedException();
        }

        public string GetPolskaFormat(string atom, out MathExpr[] exprs)
        {
            exprs = GetMathExprs(atom);
            return exprs.OrderByDescending(o => o.Priority).ThenBy(o => o.OperatorPriority).Aggregate("", (current, expr) => current + expr.Polska()+" ");
        }
    }



    public class MathExpr
    {
        public string Left { get; set; }
        public string Operator { get; set; }

        public int Priority { get; set; }
        public int OperatorPriority { get; set; }

        public string Polska()
        {
            return Operator == "" ? Left : $"{Operator} {Left}";
        }

    }
}
