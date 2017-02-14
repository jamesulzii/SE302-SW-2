import java.io.*;
import java.util.Scanner;

public class Example
{
    public String name;
    private String code;
    public static void main(String args[])
    {   
       String name;
       String code;
       System.out.println("Example");
       Scanner inp = new Scanner(System.in);
       System.out.print("name:");
       name = inp.next();
       System.out.print("code:");
       code = inp.next();
    }
    
    Example(String name, String code)
    {
        this.name = name;
        this.code = code;
        
    }
    
    public String getName()
        {
            return name;
        }
    public void setName(String newName)
        {
            name = newName;
        }
        
    private String getCode()
        {
            return code;
        }
    private void setCode(String newCode)
        {
            code = newCode;
        }
}