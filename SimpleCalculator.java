import java.util.Scanner;

public class SimpleCalculator {
    public static void main(String[] args) {
        // 스캐너 객체 생성
        Scanner scanner = new Scanner(System.in);

        // 사용자로부터 두 숫자를 입력받기
        System.out.println("첫 번째 숫자를 입력하세요:");
        double num1 = scanner.nextDouble();
  
        System.out.println("두 번째 숫자를 입력하세요:");
        double num2 = scanner.nextDouble();

        // 더하기 연산
        double sum = num1 + num2;

        // 결과 출력
        System.out.println("두 숫자의 합은: " + sum); 

        // 스캐너 종료
        scanner.close();
 
        // 종료
        System.out.println("종료");
        
    }
}
