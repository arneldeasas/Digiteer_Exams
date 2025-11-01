import { Card, Typography, Button, Chip } from "@mui/material";
import { Assignment } from "@mui/icons-material";
import TaskCardMenu from "./TaskCardMenu";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useSnackbar } from "notistack";
import { startTask } from "../Mutations/TaskMutations";
import { useMemo } from "react";
import CurrentUserHelper from "../Helpers/CurrentUserHelper";

function TaskCard({ task: { id = 1, title, description, taskStatus } }) {
  const queryClient = useQueryClient();
  const { enqueueSnackbar } = useSnackbar();
  const currentUser = useMemo(() => CurrentUserHelper.getCurrentUser(), []);

  const mutation = useMutation({
    mutationFn: startTask,
    onSuccess: () => {
      enqueueSnackbar("Task started successfully!", { variant: "success" });
      queryClient.invalidateQueries(["tasks", currentUser.id]);
    },
    onError: (error) => {
      enqueueSnackbar("Task start failed!" + error.ErrorMessage, {
        variant: "error",
      });
    },
  });

  const handleStartTask = async () => {
    await mutation.mutateAsync(id);
  };
  return (
    <Card variant="outlined" className="bg-gray-200 w-[320px] ">
      <div className="flex justify-between p-2">
        <div className=" flex items-center gap-2">
          <Assignment fontSize="small" />
          <Typography sx={{ fontWeight: 600 }} variant="body2">
            Task ID #{id}
          </Typography>
        </div>
        <div className="flex justify-end">
          {taskStatus === "Not Started" && (
            <Button
              onClick={handleStartTask}
              loading={mutation.isPending}
              size="small"
              variant="text"
            >
              Start task
            </Button>
          )}

          <TaskCardMenu key={1} id="task-menu-1" />
        </div>
      </div>

      <div className="bg-gray-100 border-y border-gray-200 h-[93.84px]">
        <div className="w-full px-4 py-2 flex flex-col  gap-2">
          {/* <Assignment fontSize="small" /> */}
          <Typography variant="body2" noWrap gutterBottom>
            {title}
          </Typography>
          <Typography variant="subtitle2" className="text-gray-600">
            {description}
          </Typography>
        </div>
      </div>

      <div className="w-full p-4 flex items-center justify-end gap-2">
        {taskStatus === "Not Started" && (
          <Chip label="Not Started" color="primary" size="small" />
        )}
        {taskStatus === "In Progress" && (
          <Chip label="In Progress" color="warning" size="small" />
        )}
      </div>
    </Card>
  );
}

export default TaskCard;
