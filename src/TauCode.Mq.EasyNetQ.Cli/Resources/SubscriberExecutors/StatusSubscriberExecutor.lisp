(defblock :name get-subscriber-status :is-top t
	(executor
		:executor-name get-subscriber-status
		:verb "status"
		:description "Gets status of the subscriber."
		:usage-samples (
			"sub status"))

	(end)
)
