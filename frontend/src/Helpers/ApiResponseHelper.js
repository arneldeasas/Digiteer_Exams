export const handleApiResponse = async (request) => {
  try {
    const response = await request();
    if (response.data.success) {
      return response.data;
    }
  } catch (error) {
    throw error.response.data;
  }
};
