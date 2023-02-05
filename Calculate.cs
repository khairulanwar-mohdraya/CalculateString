public class Calculate {
        public double CalculateString(string s)
        {
            var stack = new Stack<double>();
            var stack2 = new Stack<double>();
            double currentNumber = 0;
            char previousSign = '+';
            char paranthesisSign = '+';
            char paranthesesFinalSign = '+';
            double resultParantheses =0;

            for(int i=0; i<s.Length; i++) //Iterate all characters in string
            {
                if(s[i] >= '0' && s[i] <='9') //If current character is digit
                {
                    currentNumber = currentNumber * 10 + s[i] - '0';
                }

                if(!(s[i] >= '0' && s[i] <='9') &&  s[i]!=' ' || i==s.Length-1) //If current character is not digit & not empty
                {
                    //Perform operations inside paranthesis
                    if(previousSign == '(')
                    {
                        //Push current numbers inside paranthesis into stack
                        pushToStack(stack2,paranthesisSign, currentNumber);

                        if(s[i] == ')')
                        {
                            previousSign = ')';
                            
                            foreach(double a in stack2)
                            {
                                resultParantheses +=a; //Sum up all values in parantheses stack numbers
                            }

                            if(paranthesesFinalSign == '-')
                            {
                                resultParantheses *= -1; //set operations result sign value in parantheses
                            }
                        }
                        paranthesisSign = s[i];
                        currentNumber = 0;
                        continue;
                    }
                    else if(previousSign == '-' && s[i] == '(')
                    {
                        paranthesesFinalSign = '-';//Set parantheses operation result sign value
                    }

                    //Perform operations outside paranthesis
                    pushToStack(stack,previousSign, currentNumber);
                    previousSign = s[i];
                    currentNumber = 0;
                }
            }
            
            double result =0;
            foreach(double i in stack)
            {
                result +=i; //sum up all values in stack
            }
            if(resultParantheses != 0)
            {
                result =  result + resultParantheses;
            }
            return result;
        }

        public void pushToStack(Stack<double> stackName, char sign, double currentNumber)
        {
             if(sign == '.')
              {            
                double popStack = stackName.Pop();
                stackName.Push(popStack < 0 ? popStack+(-currentNumber/10) : popStack+(currentNumber/10));
              }
              if(sign == '-')
              {
                stackName.Push(-currentNumber);
              }
              if(sign=='+')
              {
                stackName.Push(currentNumber);
              }
              if(sign=='*')
              {
                stackName.Push(stackName.Pop()*currentNumber);
              }
              if(sign=='/')
              {
                stackName.Push(stackName.Pop()/currentNumber);
              }
        }
}