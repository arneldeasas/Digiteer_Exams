import { Card, Typography, Button, Chip } from "@mui/material";
import { Assignment } from "@mui/icons-material";
import TaskCardMenu from "./TaskCardMenu";

function TaskCard({ task: { id = 1, title, description, status } }) {
  return (
    <Card variant="outlined" className="bg-gray-200 w-[280px] ">
      <div className="flex justify-between p-2">
        <div className=" flex items-center gap-2">
          <Assignment fontSize="small" />
          <Typography sx={{ fontWeight: 600 }} variant="body2">
            Task 1
          </Typography>
        </div>
        <div className="flex justify-end">
          <Button size="small" variant="text">
            Start task
          </Button>

          <TaskCardMenu key={1} id="task-menu-1" />
        </div>
      </div>

      <div className="bg-gray-100 border-y border-gray-200">
        <div className="w-full px-4 py-2 flex items-center gap-2">
          {/* <Assignment fontSize="small" /> */}
          <Typography variant="body2">Description</Typography>
        </div>
      </div>

      <div className="w-full p-4 flex items-center justify-end gap-2">
        <Chip label="In Progress" color="info" size="small" />
      </div>
    </Card>
  );
}

export default TaskCard;
