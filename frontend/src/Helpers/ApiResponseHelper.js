export const handleApiResponse = async (request) => {
  try {
    const response = await request();
    console.log(response);

    if (response.data.success) {
      console.log(response.data);

      return response.data.data;
    }
  } catch (error) {
    throw error.response.data;
  }
};
