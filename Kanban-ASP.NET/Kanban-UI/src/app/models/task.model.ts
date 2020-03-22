export class Task {
  id: number;
  name: string;
  ownerId: number;
  startDate: Date;
  dueDate: Date;
  taskStatuts: string;
  priority: number;
  completion: number;
  assignedEmployeeId: number;
  indexTask: number;
  listId: number;
  assignedEmployee: AssignedEmployee;
  owner: Owner;
}

export class AssignedEmployee {
  id: number;
  name: string;
}

export class Owner {
  id: number;
  name: string;
}
