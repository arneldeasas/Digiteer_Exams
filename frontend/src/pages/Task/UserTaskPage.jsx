import { Add, Assignment } from "@mui/icons-material";
import { Typography, Card, Chip, IconButton, Button } from "@mui/material";
import TaskCardMenu from "../../Components/TaskCardMenu";
import TaskCard from "../../Components/TaskCard";

function UserTaskPage() {
  return (
    <div className="w-screen h-screen bg-gray-100 flex flex-col items-center">
      <Card className="max-w-[1440px] w-full m-10 p-10">
        <div className="flex justify-between">
          <Typography variant="h6">User Tasks</Typography>
          <div>
            <Button
              variant="contained"
              size="small"
              className="mr-4"
              startIcon={<Add />}
            >
              Create Task
            </Button>
          </div>
        </div>
        <div className="mt-4 flex flex-wrap">
          <TaskCard task={{}} />
        </div>
      </Card>
    </div>
  );
}

export default UserTaskPage;
