import {
  Typography,
  Card,
  CircularProgress,
  Button,
  IconButton,
} from "@mui/material";

import TaskCard from "../../Components/TaskCard";
import CreateTask from "../../Components/CreateTask";
import CurrentUserHelper from "../../Helpers/CurrentUserHelper";
import { useQuery } from "@tanstack/react-query";
import { getUserTasks } from "../../Queries/TaskQueries";
import { useMemo } from "react";
import { Logout } from "@mui/icons-material";
import { Tooltip } from "@mui/material";
import { useNavigate } from "react-router-dom";
function UserTaskPage() {
  const navigate = useNavigate();
  const currentUser = useMemo(() => CurrentUserHelper.getCurrentUser(), []);
  const { data, isLoading, isError } = useQuery({
    queryKey: ["tasks", currentUser.id],
    queryFn: async () => await getUserTasks(currentUser.id),
  });
  console.log(data, currentUser.id, isError);

  const handleLogout = () => {
    CurrentUserHelper.clearCurrentUser();
    navigate("/", { replace: true });
  };
  return (
    <div className="w-screen h-screen bg-gray-100 flex flex-col items-center">
      <Card className="max-w-[1440px] w-full p-10 " sx={{ marginTop: 5 }}>
        {isLoading && <CircularProgress size={40} />}
        <div className="flex justify-between">
          <Typography variant="h6">User Tasks</Typography>
          <div className="flex gap-4">
            <CreateTask />
            <Tooltip title="Logout">
              <IconButton
                onClick={handleLogout}
                variant="contained"
                size="small"
                className="mt-4"
              >
                <Logout />
              </IconButton>
            </Tooltip>
          </div>
        </div>
        <div className="mt-4 flex flex-wrap gap-4">
          {data && data.map((task) => <TaskCard key={task.id} task={task} />)}
          {data.length === 0 && !isLoading && (
            <Typography variant="body1">No tasks found.</Typography>
          )}
        </div>
      </Card>
    </div>
  );
}

export default UserTaskPage;
