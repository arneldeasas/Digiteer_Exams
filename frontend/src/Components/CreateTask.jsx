import {
  DialogContent,
  Dialog,
  DialogActions,
  DialogTitle,
  TextField,
  Button,
} from "@mui/material";
import { Add } from "@mui/icons-material";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import React from "react";
import { Controller, useForm } from "react-hook-form";
import { createTask } from "../Mutations/TaskMutations";
import { CreateTaskSchema } from "../Schema/TaskSchema";
import { yupResolver } from "@hookform/resolvers/yup";
import { DateTimePicker } from "@mui/x-date-pickers/DateTimePicker";
import CurrentUserHelper from "../Helpers/CurrentUserHelper";

import { useSnackbar } from "notistack";
function CreateTask() {
  const { enqueueSnackbar } = useSnackbar();
  const [open, setOpen] = React.useState(false);

  const currentUser = CurrentUserHelper.getCurrentUser();

  const queryClient = useQueryClient();

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = (event, reason) => {
    if (reason === "backdropClick") return;
    setOpen(false);
  };

  const {
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(CreateTaskSchema),
    defaultValues: {
      title: "",
      description: "",
      endDate: null,
    },
  });

  const mutation = useMutation({
    mutationFn: createTask,
    onSuccess: () => {
      enqueueSnackbar("Task Created Successfully!", { variant: "success" });
      reset();
      queryClient.invalidateQueries(["tasks", currentUser.id]);
      handleClose();
    },
    onError: (error) => {
      enqueueSnackbar("Task Creation Failed!", { variant: "error" });
    },
  });

  const onSubmit = async (data) => {
    const currentUser = CurrentUserHelper.getCurrentUser();
    console.log(currentUser);
    const taskData = {
      ...data,
      userId: parseInt(currentUser.id),
    };
    console.log(taskData);

    await mutation.mutateAsync(taskData);
  };

  return (
    <div>
      <Button
        variant="contained"
        size="small"
        className="mr-4"
        startIcon={<Add />}
        onClick={handleClickOpen}
      >
        Create Task
      </Button>
      <Dialog open={open} onClose={handleClose} fullWidth maxWidth="sm">
        <form onSubmit={handleSubmit(onSubmit)} id="subscription-form">
          <DialogTitle>Create Task</DialogTitle>
          <DialogContent>
            <div className="my-2 gap-4 flex flex-col">
              <div className="flex gap-4">
                <Controller
                  name="title"
                  control={control}
                  render={({ field }) => (
                    <TextField
                      autoComplete="title"
                      size="small"
                      label="Title"
                      placeholder="Enter task title"
                      variant="outlined"
                      className="grow"
                      helperText={errors.title?.message}
                      {...field}
                    />
                  )}
                />
                <Controller
                  name="dueDate"
                  control={control}
                  render={({ field }) => (
                    <DateTimePicker
                      {...field}
                      slotProps={{
                        textField: {
                          helperText: errors.endDate?.message,
                          size: "small",
                        },
                      }}
                      label="Due Date"
                      viewRenderers={{
                        hours: null,
                        minutes: null,
                        seconds: null,
                      }}
                    />
                  )}
                />
              </div>
              <Controller
                name="description"
                control={control}
                render={({ field }) => (
                  <TextField
                    autoComplete="description"
                    fullWidth
                    size="small"
                    label="Description"
                    placeholder="Enter task description"
                    variant="outlined"
                    helperText={errors.description?.message}
                    {...field}
                  />
                )}
              />
            </div>
          </DialogContent>
          <DialogActions>
            <Button
              type="button"
              onClick={handleClose}
              disabled={mutation.isPending}
            >
              Cancel
            </Button>
            <Button
              loading={mutation.isPending}
              type="submit"
              form="subscription-form"
            >
              Save
            </Button>
          </DialogActions>
        </form>
      </Dialog>
    </div>
  );
}

export default CreateTask;
