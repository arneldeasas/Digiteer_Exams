import { Typography, Card, CircularProgress } from "@mui/material";

import TaskCard from "../../Components/TaskCard";
import CreateTask from "../../Components/CreateTask";
import CurrentUserHelper from "../../Helpers/CurrentUserHelper";
import { useQuery } from "@tanstack/react-query";
import { getUserTasks } from "../../Queries/TaskQueries";
import { useMemo } from "react";

function UserTaskPage() {
  const currentUser = useMemo(() => CurrentUserHelper.getCurrentUser(), []);
  const { data, isLoading, isError } = useQuery({
    queryKey: ["tasks", currentUser.id],
    queryFn: async () => await getUserTasks(currentUser.id),
  });
  console.log(data, currentUser.id, isError);

  return (
    <div className="w-screen h-screen bg-gray-100 flex flex-col items-center">
      <Card className="max-w-[1440px] w-full m-10 p-10">
        {isLoading && <CircularProgress size={40} />}
        <div className="flex justify-between">
          <Typography variant="h6">User Tasks</Typography>
          <div>
            <CreateTask />
          </div>
        </div>
        <div className="mt-4 flex flex-wrap gap-4">
          {data && data.map((task) => <TaskCard key={task.id} task={task} />)}
        </div>
      </Card>
    </div>
  );
}

export default UserTaskPage;
