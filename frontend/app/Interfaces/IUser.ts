interface User {
  id: number;
  username: string;
  password: string;
  name: string;
  role: UserRole;
  departmentId: number;
}

enum UserRole {
  Standard = 1,
  Manager = 2,
  Admin = 3,
}

interface UpdateUserRequestDto {
  name?: string;
  role?: UserRole;
  departmentId?: number;
}

interface CreateUserDto {
  email: string;
  username: string;
  password: string;
  name: string;  
  role: number;
  departmentId: number;
}

interface VerifyPassword {
  username: string;
  password: string;
}